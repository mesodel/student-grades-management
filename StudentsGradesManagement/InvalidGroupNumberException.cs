using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsGradesManagement
{
    class InvalidGroupNumberException:Exception
    {
        public string GroupId { get; set; }

        public InvalidGroupNumberException(string groupId)
        {
            GroupId = groupId;
        }
        public override string Message
        {
            get
            {
                return "The group ID "+GroupId+" has an incorrect format. Only numbers!";
            }
        }
    }
}
