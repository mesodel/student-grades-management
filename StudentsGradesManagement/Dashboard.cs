using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGradesManagement
{
    [Serializable]
   public class Dashboard
    {
        public int GroupId { get; set; }
        public List<Student> students { get; set; }

        public Dashboard(int groupId)
        {
            GroupId = groupId;
            students = new List<Student>();
        }
    }
}
