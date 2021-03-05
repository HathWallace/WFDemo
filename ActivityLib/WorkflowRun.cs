using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.IO;
using System.Runtime.DurableInstancing;
using System.Threading;

namespace ActivityLib
{
    public delegate void Delegate(WorkflowApplicationIdleEventArgs er = null, bool isIdle = false);

    public class WorkflowRun : IDisposable
    {
        public string InstanceId => wfApp?.Id.ToString() ?? "";

        //public static string SqlConfig => $@"Data Source={Environment.MachineName};Initial Catalog=WorkflowDB;Integrated Security=TRUE";

        public static string SqlConfig => File.ReadAllText("SqlConfig.txt");

        private Delegate refreshEvent;

        private WorkflowApplication wfApp;

        private AutoResetEvent syncEvent = new AutoResetEvent(false);

        public WorkflowRun(int id, Delegate refreshEvent, bool persist = false)
        {
            this.refreshEvent = refreshEvent;

            var inputs = new Dictionary<string, object> { { "Id", id } };
            wfApp = new WorkflowApplication(new MyWorkflow(), inputs);
            if (persist)
                wfApp.InstanceStore = new SqlWorkflowInstanceStore(SqlConfig);
            WorkFlowEvent(wfApp/*, syncEvent*/);
            wfApp.Run();
            syncEvent.WaitOne();

        }

        public WorkflowRun(string guid, Delegate refreshEvent)
        {
            this.refreshEvent = refreshEvent;

            wfApp = new WorkflowApplication(new MyWorkflow());
            wfApp.InstanceStore = new SqlWorkflowInstanceStore(SqlConfig);
            wfApp.Load(Guid.Parse(guid));
            WorkFlowEvent(wfApp/*, syncEvent*/);
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

        public void Cancel()
        {
            wfApp.Cancel();
            wfApp = null;
            Dispose();
        }

        public void Dispose()
        {
            if (wfApp?.InstanceStore != null)
                wfApp?.Unload();
            else
                wfApp?.Cancel();

        }

        private void WorkFlowEvent(WorkflowApplication app/*, AutoResetEvent syncEvent*/)
        {
            #region 工作流生命周期事件
            app.Unloaded = delegate (WorkflowApplicationEventArgs er)
            {
                refreshEvent();
                Console.WriteLine("工作流 {0} 卸载.", er.InstanceId);
                syncEvent.Set();
            };
            app.Completed = delegate (WorkflowApplicationCompletedEventArgs er)
            {
                refreshEvent();
                Console.WriteLine("工作流 {0} 完成.", er.InstanceId);
                syncEvent.Set();
            };
            app.Aborted = delegate (WorkflowApplicationAbortedEventArgs er)
            {
                refreshEvent();
                Console.WriteLine("工作流 {0} 终止.", er.InstanceId);
            };
            app.Idle = delegate (WorkflowApplicationIdleEventArgs er)
            {
                refreshEvent(er, true);
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
                return PersistableIdleAction.Persist;
            };
            app.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs er)
            {
                refreshEvent();
                Console.WriteLine("OnUnhandledException in Workflow {0}\n{1}", er.InstanceId, er.UnhandledException.Message);
                return UnhandledExceptionAction.Cancel;
            };
            #endregion
        }

    }
}