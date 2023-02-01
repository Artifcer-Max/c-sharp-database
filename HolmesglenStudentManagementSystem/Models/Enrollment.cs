using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.Models
{
    public class Enrollment
    {
        public string Id;
        public string StudentId;
        public string SubjectId;

        public Enrollment()
        {
            Id = "";
            StudentId = "";
            SubjectId = "";
        }

        public Enrollment(string id, string studentId, string subjectId)
        {
            Id = id;
            StudentId = studentId;
            SubjectId = subjectId;
        }
    }
}
