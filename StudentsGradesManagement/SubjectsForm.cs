using MyChart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsGradesManagement
{
    public partial class SubjectsForm : Form
    {
        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;Persist Security Info=True";
        List<Subject> subjects;
        private int _studId;
        public SubjectsForm(List<Subject> sjs, int studentId)
        {
            InitializeComponent();
            subjects = sjs;
            _studId = studentId;
        }

        private void tbSjCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int code = int.Parse(tbSjCode.Text);
                if (code > 10000 || code < 1)
                {
                    epCode.SetError(tbSjCode, "Code <10000 and >0");
                    e.Cancel = true;
                }
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Parse failed", "error");
                tbSjCode.Text = "";
            }
        }

        private void tbSjCode_Validated(object sender, EventArgs e)
        {
            epCode.Clear();
        }

        private void tbSjName_Validating(object sender, CancelEventArgs e)
        {
            string name = tbSjName.Text.Trim();
            if(name.Length<2)
            {
                epSjName.SetError(tbSjName, "Name length > one letter");
                e.Cancel = true;
            }
        }

        private void tbSjName_Validated(object sender, EventArgs e)
        {
            epSjName.Clear();
        }

        private void tbGrade_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                float grade = float.Parse(tbGrade.Text);
                if (grade > 10 || grade < 1)
                {
                    epGrade.SetError(tbGrade, "Grade <10 and >0");
                    e.Cancel = true;
                }
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Parse failed", "error");
                tbGrade.Text = "";
            }
        }

        private void tbGrade_Validated(object sender, EventArgs e)
        {
            epGrade.Clear();
        }

        public void DisplayInListView()
        {
            lvSubjects.Items.Clear();
            foreach (var s in subjects)
            {
                ListViewItem item = new ListViewItem(s.SjId.ToString());
                item.SubItems.Add(s.Sjname);
                item.SubItems.Add(s.Grade.ToString());
                item.Tag = s;
                lvSubjects.Items.Add(item);
            }
        }

        public void AddSubject(Subject subject)
        {
            var queryString = "insert into Subjects(SubjectId,StudentId,SubjectName,Grade) values(@SubjectId,@StudentId,@SubjectName,@Grade);";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                var insertCommand = new OleDbCommand(queryString, connection);
                var subjectIdParameter = new OleDbParameter("@SubjectId", subject.SjId);
                var studentIdParameter = new OleDbParameter("@StudentId",subject.StudentId);
                var subjectNameParameter = new OleDbParameter("@SubjectName", subject.Sjname);
                var gradeParameter = new OleDbParameter("@Grade", subject.Grade);
                insertCommand.Parameters.Add(subjectIdParameter);
                insertCommand.Parameters.Add(studentIdParameter);
                insertCommand.Parameters.Add(subjectNameParameter);
                insertCommand.Parameters.Add(gradeParameter);
                insertCommand.ExecuteNonQuery();
                subjects.Add(subject);

            }

        }
        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            Subject s = new Subject(int.Parse(tbSjCode.Text),_studId,tbSjName.Text, float.Parse(tbGrade.Text));
            AddSubject(s);
            DisplayInListView();
            tbGrade.Clear();
            tbSjCode.Clear();
            tbSjName.Text = String.Empty;
        }

        public void LoadSubjects()
        {
            string queryString = "SELECT * FROM Subjects where StudentId=" + _studId;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand sqlCommand = new OleDbCommand(queryString, connection);
                OleDbDataReader sqlReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlReader.Read())
                    {
                        int subjectId = (int) sqlReader["SubjectId"];
                        int studId = (int)sqlReader["StudentId"];
                        string subName = (string)sqlReader["SubjectName"];
                        double grade = (double)sqlReader["Grade"];
                        var subject = new Subject(subjectId, studId, subName, (float)grade);
                        subjects.Add(subject);
                    }
                }
                finally
                {
                    sqlReader.Close();
                }
            }
        }

        public void UpdateSubject(Subject subject)
        {
            string queryString = "UPDATE Subjects set Grade=@Grade WHERE SubjectId=" + subject.SjId;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                var insertCommand = new OleDbCommand(queryString, connection);
              
                var GradeParameter = new OleDbParameter("@Grade", subject.Grade);
              
                insertCommand.Parameters.Add(GradeParameter);
                insertCommand.ExecuteNonQuery();
            }
        }

        private void btnUpdateSj_Click(object sender, EventArgs e)
        {
            try
            { 
                var subject = lvSubjects.SelectedItems[0].Tag as Subject;
                subject.Grade = float.Parse(tbGrade.Text);
                UpdateSubject(subject);
                DisplayInListView();
            }
                catch(FormatException ex)
            {
                throw new InvalidGradeFormatException(tbGrade.Text);
            }
               
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File | *.txt";
            saveFileDialog.Title = "Save as text file";
            if(saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {        
                    foreach(var subject in subjects)
                    {
                        sw.WriteLine("StudentId: " + _studId + ", SubjectName: " + subject.Sjname + ", Grade: " + subject.Grade);
                    }
                }
            }
        }

        private void SubjectsForm_Load(object sender, EventArgs e)
        {
            try
            {
                if(subjects.Count == 0)
                    LoadSubjects();
                DisplayInListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int currentSubjectIndex = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Microsoft Sans Serif", 24);
            var pageSettings = printDocument1.DefaultPageSettings;

            var intPrintAreaHeight = pageSettings.PaperSize.Height - pageSettings.Margins.Top - pageSettings.Margins.Bottom;
            var intPrintAreaWidth = pageSettings.PaperSize.Width - pageSettings.Margins.Left - pageSettings.Margins.Right;

            var marginLeft = pageSettings.Margins.Left;
            var marginTop = pageSettings.Margins.Top;


            if (printDocument1.DefaultPageSettings.Landscape)
            {
                var intTemp = intPrintAreaHeight;
                intPrintAreaHeight = intPrintAreaWidth;
                intPrintAreaWidth = intTemp;
            }

            const int rowHeight = 40;
            var columnWidth = intPrintAreaWidth / 3;
            StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit);
            fmt.Trimming = StringTrimming.EllipsisCharacter;
            var currentY = marginTop;
            while (currentSubjectIndex < subjects.Count)
            {
                var currentX = marginLeft;
                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    columnWidth,
                    rowHeight);
                e.Graphics.DrawString(
                    subjects[currentSubjectIndex].SjId.ToString(),
                    font,
                    Brushes.Black,
                    new RectangleF(currentX, currentY, columnWidth, rowHeight),  fmt);

                currentX += columnWidth;

                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    columnWidth,
                    rowHeight);
                e.Graphics.DrawString(
                    subjects[currentSubjectIndex].Sjname,
                    font,
                    Brushes.Black,
                    currentX,
                    currentY,
                    fmt);
                currentX += columnWidth;

                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    columnWidth,
                    rowHeight);
                e.Graphics.DrawString(
                    subjects[currentSubjectIndex].Grade.ToString(),
                    font,
                    Brushes.Black,
                    currentX,
                    currentY,
                    fmt);

                currentSubjectIndex++;
                currentY += rowHeight;

                if (currentY + rowHeight > intPrintAreaHeight)
                {
                    e.HasMorePages = true;
                    break;
                }
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            currentSubjectIndex = 0;
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to load the document for Print Preview. Make sure you currently have access to a printer. A printer must be connected and accessible for Print Preview to work.");
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void SubjectsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Alt && e.KeyCode==Keys.F)
            {
                fileToolStripMenuItem.Visible = true;
            }
        }

        private void btnStrat_Click(object sender, EventArgs e)
        {
            MyChartValues[] values = new MyChartValues[subjects.Count];

            for (int i = 0; i < subjects.Count; i++)
                values[i] = new MyChartValues(subjects[i].Sjname, subjects[i].Grade);

            var form = new StatisticsForm(values);
            form.Show();
        }
    }
}
