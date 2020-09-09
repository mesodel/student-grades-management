using System;

namespace StudentsGradesManagement
{
    [Serializable]
    public class Subject
    {
        public int StudentId { get; set; }
        public int SjId { get; set; }
        public string Sjname { get; set; }
        public float Grade { get; set; }

         public Subject(int id,int studentId,string sjn,float grade)
         {
              SjId = id;
              StudentId = studentId;  
              Sjname = sjn;
              Grade = grade;
         }
    }

   
}
