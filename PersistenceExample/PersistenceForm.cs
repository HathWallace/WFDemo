using System;
using System.Activities;
using System.Activities.Hosting;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using ActivityLib;

namespace PersistenceExample
{
    public partial class PersistenceForm : Form
    {
        private WorkflowRun workflowRun;

        public PersistenceForm()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            UpdateGuids();
            UpdateButton();

        }

        private void createBTN_Click(object sender, EventArgs e)
        {
            workflowRun = new WorkflowRun(0, MyInvoke, true);
            guidBox.Items.Add(workflowRun.InstanceId);
            guidBox.SelectedItem = workflowRun.InstanceId;
        }

        private void loadBTN_Click(object sender, EventArgs e)
        {
            workflowRun?.Dispose();
            workflowRun = new WorkflowRun(guidBox.Text, MyInvoke);
        }

        private void unloadBTN_Click(object sender, EventArgs e)
        {
            workflowRun?.Dispose();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (guidBox.Text != "") loadBTN_Click(sender, e);
            workflowRun?.Cancel();
            workflowRun = null;
        }

        private void acceptBTN_Click(object sender, EventArgs e)
        {
            workflowRun.Resume(nameBox.Text, true);
        }

        private void rejectBTN_Click(object sender, EventArgs e)
        {
            workflowRun.Resume(nameBox.Text, false);
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

        private string[] GetGuids()
        {
            string str = "SELECT Id FROM [System.Activities.DurableInstancing].InstancesTable;";
            var list = new List<string>();

            using (var conn = new SqlConnection(WorkflowRun.SqlConfig))
            {
                conn.Open();

                var dataReader = new SqlCommand(str, conn).ExecuteReader();
                while (dataReader.Read())
                {
                    list.Add(dataReader["Id"].ToString());
                }

                conn.Close();

            }

            return list.ToArray();
        }

        private void UpdateGuids()
        {
            guidBox.Items.Clear();
            guidBox.Items.AddRange(GetGuids());
            if (guidBox.Items.Count != 0)
                guidBox.SelectedIndex = 0;
            else
                guidBox.Text = "";

        }

        private void UpdateBookmark(IEnumerable<BookmarkInfo> bookmarks, out bool? countersign)
        {
            nameBox.Items.Clear();
            if (bookmarks == null)
            {
                countersign = null;
                nameBox.Text = "";
                return;
            }

            countersign = false;
            foreach (var item in bookmarks)
            {
                if (item.BookmarkName == "Countersign")
                    countersign = true;
                nameBox.Items.Add(item.BookmarkName);
            }
            nameBox.SelectedIndex = 0;

        }

        private void UpdateButton(bool? state = null)
        {
            createBTN.Enabled = false;
            getNamesBTN.Enabled = false;
            acceptBTN.Enabled = false;
            rejectBTN.Enabled = false;

            if (state == null)
            {
                createBTN.Enabled = true;
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

        private void MyInvoke(WorkflowApplicationIdleEventArgs er = null, bool isIdle = false)
        {
            bool? countersign;

            UpdateGuids();
            UpdateBookmark(er?.Bookmarks, out countersign);
            UpdateButton(countersign);

        }

    }
}
