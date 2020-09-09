using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsGradesManagement
{
    public partial class StudentsForm : Form
    {
        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;Persist Security Info=True";
        private int _groupId;
        List<Student> students;
        public StudentsForm(List<Student>std, int groupId)
        {
            InitializeComponent();
            students = std;
            _groupId = groupId;
        }

        private void tbStudentID_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int id = int.Parse(tbStudentID.Text);
                if (id > 1000 || id < 1)
                {
                    epStudentID.SetError(tbStudentID, "Id >=1 and <=1000");
                    e.Cancel = true;
                }
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Parse has failed", "Error");
                tbStudentID.Text = "";
            }
            
        }

        private void tbStudentID_Validated(object sender, EventArgs e)
        {
            epStudentID.Clear();
        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            string firstName = tbFirstName.Text.Trim();
            if(firstName.Length<2)
            {
                epFirstName.SetError(tbFirstName, "First name must have more than 1 letter!");
                e.Cancel = true;
            }
        }

        private void tbFirstName_Validated(object sender, EventArgs e)
        {
            epFirstName.Clear();
        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            string lastName = tbLastName.Text.Trim();
            if (lastName.Length < 2)
            {
                epLastName.SetError(tbLastName, "Last name must have more than 1 letter!");
                e.Cancel = true;
            }
        }

        private void tbLastName_Validated(object sender, EventArgs e)
        {
            epLastName.Clear();
        }

        public void DisplayInListView()
        {
            lvStudents.Items.Clear();
            foreach(Student s in students)
            {
                ListViewItem item = new ListViewItem(s.StudentId.ToString());
                item.SubItems.Add(s.FirstName);
                item.SubItems.Add(s.LastName);
                item.Tag = s;
                lvStudents.Items.Add(item);
            }
        }

        public void AddStudent(Student student)
        {
            var queryString = "insert into Students(StudentId,GroupId,FirstName,LastName) values(@StudentId,@GroupId,@FirstName,@LastName);";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                var insertCommand = new OleDbCommand(queryString, connection);
                var studentGroupIdParameter = new OleDbParameter("@GroupId", student.GroupId);
                var studentIdParameter = new OleDbParameter("@StudentId", student.StudentId);
                var studentFirstNameParameter = new OleDbParameter("@FirstName", student.FirstName);
                var studentLastNameParameter = new OleDbParameter("@LastName", student.LastName);
                insertCommand.Parameters.Add(studentIdParameter);
                insertCommand.Parameters.Add(studentGroupIdParameter);
                insertCommand.Parameters.Add(studentFirstNameParameter);
                insertCommand.Parameters.Add(studentLastNameParameter);
                insertCommand.ExecuteNonQuery();
                students.Add(student);

            }
        }
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            Student s = new Student(_groupId, int.Parse(tbStudentID.Text),tbFirstName.Text,tbLastName.Text);
            if (s.LastName.Length > 30)
                throw new Exception("The length of the name must be less than 30!");
            else
            {
                AddStudent(s);
                DisplayInListView();
                tbLastName.Text = tbFirstName.Text = String.Empty;
                tbStudentID.Clear();
            }
        }

        public void LoadStudents()
        {
            string queryString = "SELECT * FROM Students where GroupId=" + _groupId;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);
                OleDbDataReader sqlReader = sqlCommand.ExecuteReader();
                try
                {
                    while(sqlReader.Read())
                    {
                        var student = new Student((int)sqlReader["GroupId"], (int)sqlReader["StudentId"], 
                            (string)sqlReader["FirstName"], (string)sqlReader["LastName"]);
                        students.Add(student);
                    }
                }
                finally
                {
                    sqlReader.Close();
                }
            }
        }

        public void DeleteStudent(Student student)
        {
            const string queryString = "DELETE FROM Students WHERE StudentId=@StudentId";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);
                var StudentIdParameter = new OleDbParameter("@StudentId", student.StudentId);
                sqlCommand.Parameters.Add(StudentIdParameter);
                sqlCommand.ExecuteNonQuery();
                students.Remove(student);
            }
        }

        public void UpdateStudent(Student student)
        {
            string queryString = "UPDATE Students set FirstName=@FirstName,LastName=@LastName WHERE StudentId="+student.StudentId;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                var insertCommand = new OleDbCommand(queryString, connection);
                var studentFirstNameParameter = new OleDbParameter("@FirstName", student.FirstName);
                var studentLastNameParameter = new OleDbParameter("@LastName", student.LastName);
                insertCommand.Parameters.Add(studentFirstNameParameter);
                insertCommand.Parameters.Add(studentLastNameParameter);
                insertCommand.ExecuteNonQuery();
            }
        }

        private void lvStudents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var student = lvStudents.SelectedItems[0].Tag as Student;
            var form = new SubjectsForm(student.subjects, student.StudentId);
            form.Show();
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            var student = lvStudents.SelectedItems[0].Tag as Student;

            student.FirstName = tbFirstName.Text;
            student.LastName = tbLastName.Text;

            UpdateStudent(student);
            DisplayInListView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteStudent((Student)lvStudents.SelectedItems[0].Tag);
            DisplayInListView();
        }

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                if(students.Count == 0)
                    LoadStudents();
                DisplayInListView();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StudentsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Alt && e.KeyCode==Keys.U)
            {
                btnUpdateStudent.Focus();
            }
        }
    }
}
