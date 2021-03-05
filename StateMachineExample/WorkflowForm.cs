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
            UpdateControl();

        }

        private void startBTN_Click(object sender, EventArgs e)
        {
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
            workflowRun.Dispose();
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

        }

    }
}
