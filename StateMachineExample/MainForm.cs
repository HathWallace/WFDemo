using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ActivityLib;
using ActivityLib.Toolbox;

namespace StateMachineExample
{
    public partial class MainForm : Form
    {
        private int id = -1;

        private SqlWorkflowInstanceStore instanceStore = null;

        private WorkflowApplication instance = null;

        public MainForm(SqlWorkflowInstanceStore instanceStore = null)
        {
            this.instanceStore = instanceStore;
            InitializeComponent();

            if (File.Exists(Dao.Path)) File.Delete(Dao.Path);
            UpdateControl();

        }

        private void startBTN_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object> { { "Id", ++id } };
            instance = new WorkflowApplication(new MyWorkflow(), dict);
            instance.InstanceStore = instanceStore;
            WorkFlowEvent(instance);
            instance.Run();
            new Dao().Create(id);
        }

        private void getNamesBTN_Click(object sender, EventArgs e)
        {
            var list = new SortedSet<string>()
            {
                "h2",
                "h3",
                "h4",
                "super",
            };
            instance.ResumeBookmark(nameBox.Text, list);
            new Dao().Update(id, false);
        }

        private void acceptBTN_Click(object sender, EventArgs e)
        {
            if (instance == null) return;
            instance.ResumeBookmark(nameBox.Text, true);
        }

        private void rejectBTN_Click(object sender, EventArgs e)
        {
            if (instance == null) return;
            instance.ResumeBookmark(nameBox.Text, false);
        }

        private void restartBTN_Click(object sender, EventArgs e)
        {
            instance?.Abort();
        }

        private void WorkFlowEvent(WorkflowApplication app)
        {
            #region 工作流生命周期事件
            app.Completed = delegate (WorkflowApplicationCompletedEventArgs er)
            {
                MyInvoke(er);
                instance = null;
                Console.WriteLine("workflowCompleted:{0}", er.CompletionState.ToString());
            };
            app.Aborted = delegate (WorkflowApplicationAbortedEventArgs er)
            {
                MyInvoke(er);
                instance = null;
                Console.WriteLine("aborted ,Reason:{0}", er.Reason.Message);
            };
            app.Idle = delegate (WorkflowApplicationIdleEventArgs er)
            {
                MyInvoke(er, true);
                Console.WriteLine("Idle:{0}", er.InstanceId);
                Console.WriteLine("--------BookmarkName---------------------------");
                foreach (var item in er.Bookmarks)
                {
                    Console.WriteLine("{0}", item.BookmarkName);
                }
                Console.WriteLine("================================");

            };
            app.OnUnhandledException = delegate (WorkflowApplicationUnhandledExceptionEventArgs er)
            {
                MyInvoke(er);
                Console.WriteLine("unhandledException:{0}", er.UnhandledException.Message);
                return UnhandledExceptionAction.Cancel;
            };
            #endregion
        }

        private void UpdateControl(bool? state = null)
        {
            startBTN.Enabled = false;
            getNamesBTN.Enabled = false;
            acceptBTN.Enabled = false;
            rejectBTN.Enabled = false;

            if (state == null)
            {
                startBTN.Enabled = true;
                nameBox.Items.Clear();
            }
            else if (!(bool)state)
            {
                acceptBTN.Enabled = true;
                rejectBTN.Enabled = true;
            }
            else
            {
                getNamesBTN.Enabled = true;
            }

        }

        private void MyInvoke(WorkflowApplicationEventArgs er, bool isIdle = false)
        {
            Invoke(new Action(() =>
            {
                nameBox.Items.Clear();

                if (!isIdle)
                {
                    UpdateControl();
                    if (instanceStore != null) Close();
                    return;
                }

                UpdateControl(new Dao().Read(id));
                var idleEr = (WorkflowApplicationIdleEventArgs)er;
                foreach (var item in idleEr.Bookmarks)
                {
                    nameBox.Items.Add(item.BookmarkName);
                }
                nameBox.SelectedIndex = 0;

            }));
        }

    }
}
