using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGradesManagement
{
    [Serializable]
    public class Student
    {
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Subject> subjects { get; set; }

        public Student(int groupId,int studentId, string fname,string lname)
        {
            GroupId = groupId;
            StudentId = studentId;
            FirstName = fname;
            LastName = lname;
            subjects = new List<Subject>();
        }
    }
}
