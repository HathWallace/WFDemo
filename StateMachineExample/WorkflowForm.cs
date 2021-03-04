using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ActivityLib;
using ActivityLib.Toolbox;

namespace StateMachineExample
{
    public partial class WorkflowForm : Form
    {
        private int id = -1;

        //private WorkflowApplication wfApp = null;

        private WorkflowRun workflowRun;

        public WorkflowForm()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            if (File.Exists(Dao.Path)) File.Delete(Dao.Path);
            UpdateControl();

        }

        private void startBTN_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object> { { "Id", id } };
            workflowRun = new WorkflowRun(++id, MyInvoke);

        }

        private void getNamesBTN_Click(object sender, EventArgs e)
        {
            var list = new SortedSet<string>
            {
                "h2",
                "h3",
                "h4",
                "super",
            };
            workflowRun.Resume(nameBox.Text, list);
        }

        private void acceptBTN_Click(object sender, EventArgs e)
        {
            workflowRun.Resume(nameBox.Text, true);
        }

        private void rejectBTN_Click(object sender, EventArgs e)
        {
            workflowRun.Resume(nameBox.Text, false);
        }

        private void restartBTN_Click(object sender, EventArgs e)
        {
            workflowRun.Abort();
        }

        private void WorkFlowEvent(WorkflowApplication app)
        {
            #region 工作流生命周期事件
            app.Completed = delegate (WorkflowApplicationCompletedEventArgs er)
            {
                MyInvoke(er);
                Console.WriteLine("workflowCompleted:{0}", er.CompletionState.ToString());
            };
            app.Aborted = delegate (WorkflowApplicationAbortedEventArgs er)
            {
                MyInvoke(er);
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
            app.PersistableIdle = delegate (WorkflowApplicationIdleEventArgs er)
            {
                return PersistableIdleAction.Unload;
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
            //Invoke(new Action(() =>
            //{
                nameBox.Items.Clear();

                if (!isIdle)
                {
                    UpdateControl();
                    return;
                }

                bool countersign = false;
                var idleEr = (WorkflowApplicationIdleEventArgs)er;
                foreach (var item in idleEr.Bookmarks)
                {
                    if (item.BookmarkName == "Countersign")
                        countersign = true;
                    nameBox.Items.Add(item.BookmarkName);
                }
                UpdateControl(countersign);
                nameBox.SelectedIndex = 0;

            //}));
        }

    }
}
