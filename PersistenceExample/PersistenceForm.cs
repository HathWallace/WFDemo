using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActivityLib;
using StateMachineExample;

namespace PersistenceExample
{
    public partial class PersistenceForm : Form
    {
        private string sqlConfig => $@"Data Source={Environment.MachineName};Initial Catalog=WorkflowDB;Integrated Security=TRUE";

        private SqlWorkflowInstanceStore instanceStore;

        public PersistenceForm()
        {
            InitializeComponent();
            instanceStore = new SqlWorkflowInstanceStore(sqlConfig);
        }

        private void createBTN_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object> {{"Id", 0}};
            var wfApp = new WorkflowApplication(new MyWorkflow(), dict);
            var syncEvent = new AutoResetEvent(false);
            WorkFlowEvent(wfApp, syncEvent);
            wfApp.InstanceStore = instanceStore;
            wfApp.Run();
            syncEvent.WaitOne();
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
                Console.WriteLine("工作流 {0} 完成.", er.InstanceId);
                syncEvent.Set();
            };
            app.Aborted = delegate (WorkflowApplicationAbortedEventArgs er)
            {
                Console.WriteLine("工作流 {0} 终止.", er.InstanceId);
            };
            app.Idle = delegate (WorkflowApplicationIdleEventArgs er)
            {
                Console.WriteLine("工作流 {0} 空闲.", er.InstanceId);
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
                Console.WriteLine("OnUnhandledException in Workflow {0}\n{1}", er.InstanceId, er.UnhandledException.Message);
                return UnhandledExceptionAction.Terminate;
            };
            #endregion
        }

        private void runBTN_Click(object sender, EventArgs e)
        {
            if (instanceIdTXT.Text == "")
            {
                MessageBox.Show("请输入Guid");
                return;
            }
            var frm = new WorkflowForm();
            frm.Show();
        }
    }
}
