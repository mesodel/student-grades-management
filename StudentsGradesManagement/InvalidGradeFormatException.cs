using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGradesManagement
{
    class InvalidGradeFormatException:Exception
    {
        string grade { get; set; }

        public InvalidGradeFormatException(string grade)
        {
            this.grade = grade;
        }
        public override string Message
        {
            get
            {
                return "The grade " + grade + " has an invalid format. Please insert only numbers!";
            }
        }
    }
}
