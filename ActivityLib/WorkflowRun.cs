using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Threading;

namespace ActivityLib
{
    public delegate void Delegate(WorkflowApplicationEventArgs er, bool isIdle = false);

    public class WorkflowRun : IDisposable
    {
        public Delegate RefreshEvent;

        private static string sqlConfig =>
            $@"Data Source={Environment.MachineName};Initial Catalog=WorkflowDB;Integrated Security=TRUE";

        private WorkflowApplication wfApp;

        private AutoResetEvent syncEvent = new AutoResetEvent(false);

        private SqlWorkflowInstanceStore instanceStore = new SqlWorkflowInstanceStore(sqlConfig);

        public WorkflowRun(int id, Delegate refreshEvent)
        {
            RefreshEvent = refreshEvent;

            var inputs = new Dictionary<string, object> { { "Id", id } };
            wfApp = new WorkflowApplication(new MyWorkflow(), inputs);
            WorkFlowEvent(wfApp, syncEvent);
            wfApp.Run();
            syncEvent.WaitOne();

        }

        public void Resume(string bookmark, bool agree)
        {
            wfApp.ResumeBookmark(bookmark, agree);
        }

        public void Resume(string bookmark, SortedSet<string> list)
        {
            wfApp.ResumeBookmark(bookmark, list);
        }

        public void Abort()
        {
            wfApp.Abort();
        }

        public void Dispose()
        {
            wfApp.Unload();
        }

        private void WorkFlowEvent(WorkflowApplication app, AutoResetEvent syncEvent)
        {
            #region 工作流生命周期事件
            app.Unloaded = delegate (WorkflowApplicationEventArgs er)
            {
                Console.WriteLine("工作流 {0} 卸载.", er.InstanceId);
                syncEvent.Set();
            };
            app.Completed = delegate (WorkflowApplicationCompletedEventArgs er)
            {
                RefreshEvent(er);
                Console.WriteLine("工作流 {0} 完成.", er.InstanceId);
                syncEvent.Set();
            };
            app.Aborted = delegate (WorkflowApplicationAbortedEventArgs er)
            {
                RefreshEvent(er);
                Console.WriteLine("工作流 {0} 终止.", er.InstanceId);
            };
            app.Idle = delegate (WorkflowApplicationIdleEventArgs er)
            {
                RefreshEvent(er, true);
                Console.WriteLine("工作流 {0} 空闲.", er.InstanceId);
                Console.WriteLine("------------------BookmarkName------------------");
                foreach (var item in er.Bookmarks)
                {
                    Console.WriteLine("{0}", item.BookmarkName);
                }
                Console.WriteLine("================================================");
                syncEvent.Set(); //这里要唤醒，不让的话，当创建了一个书签之后，界面就卡死了。
            };
            app.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs er)
            {
                Console.WriteLine("持久化 {0} ", er.InstanceId);
                return PersistableIdleAction.Unload;
                //return PersistableIdleAction.Persist;
            };
            app.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs er)
            {
                RefreshEvent(er);
                Console.WriteLine("OnUnhandledException in Workflow {0}\n{1}", er.InstanceId, er.UnhandledException.Message);
                return UnhandledExceptionAction.Terminate;
            };
            #endregion
        }

    }
}