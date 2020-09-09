using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsGradesManagement
{
    public partial class MainForm : Form
    {
        public static  string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;Persist Security Info=True";

       public List<Dashboard> dashboards;

        public MainForm()
        {
            InitializeComponent();
            dashboards = new List<Dashboard>();
        }

        private void tbGroupNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int groupNo = int.Parse(tbGroupNo.Text);
                if (groupNo < 1000 || groupNo > 9999)
                {
                    epGroupNo.SetError(tbGroupNo, "Group no >=1000 and <10000!");
                    e.Cancel = true;
                }
            }
            catch(Exception ex)
            {
                e.Cancel = true;
                epGroupNo.SetError(tbGroupNo, "Group no >=1000 and <10000!");
            }
        }

        private void tbGroupNo_Validated(object sender, EventArgs e)
        {
            epGroupNo.Clear();
        }

        private void DisplayInListView()
        {
            lvGroups.Items.Clear();

            foreach(Dashboard d in dashboards)
            {
                ListViewItem item = new ListViewItem(d.GroupId.ToString());
                item.Tag = d;
                lvGroups.Items.Add(item);
            }
        }

        private void AddDashboard(Dashboard dashboard)
        {
            var queryString = "insert into Dashboards(GroupId) values(@GroupId);";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                var insertCommand = new OleDbCommand(queryString, connection);
                var groupIdParameter = new OleDbParameter("@GroupId", dashboard.GroupId);
                insertCommand.Parameters.Add(groupIdParameter);
                insertCommand.ExecuteNonQuery();
                dashboards.Add(dashboard);
            }
                
        }
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                Dashboard newDashboard = new Dashboard(int.Parse(tbGroupNo.Text));
                AddDashboard(newDashboard);

                DisplayInListView();
                tbGroupNo.Clear();
            }
            catch(FormatException ex)
            {
                throw new InvalidGroupNumberException(tbGroupNo.Text);
            }
        }

        public void LoadDashboards()
        {
            const string queryString = "SELECT * FROM Dashboards";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);
                OleDbDataReader sqlReader = sqlCommand.ExecuteReader();
                try
                {
                    while(sqlReader.Read())
                    {
                        var dashboard = new Dashboard((int)sqlReader["GroupId"]);
                        dashboards.Add(dashboard);
                    }
                }
                finally
                {
                    sqlReader.Close();
                }
            }
        }
        public void DeleteDashboard(Dashboard dashboard)
        {
            const string queryString = "DELETE FROM Dashboards WHERE GroupId=@id";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);
                var idParameter = new OleDbParameter("@GroupId", dashboard.GroupId);
                sqlCommand.Parameters.Add(idParameter);
                sqlCommand.ExecuteNonQuery();
                dashboards.Remove(dashboard);
            }
        }
        private void lvGroups_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var dashboard = lvGroups.SelectedItems[0].Tag as Dashboard;
            var form = new StudentsForm(dashboard.students, dashboard.GroupId);
            form.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteDashboard((Dashboard)lvGroups.SelectedItems[0].Tag);
            DisplayInListView();
        }

        private void serializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter serialize = new BinaryFormatter();
            using(FileStream s = File.Create("serialized.bin"))
            {
                serialize.Serialize(s, dashboards);
            }
        }

        private void deserializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using(FileStream s = File.OpenRead("serialized.bin"))
            {
                dashboards = (List<Dashboard>) binaryFormatter.Deserialize(s);
                DisplayInListView();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDashboards();
                DisplayInListView();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Alt && e.KeyCode == Keys.F)
            {
                fileToolStripMenuItem.Visible = true;
            }
        }

    }
}
