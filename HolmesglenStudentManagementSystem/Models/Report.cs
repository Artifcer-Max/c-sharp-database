using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.Models
{
    public class Report
    {
        public string StudentId;
        public string SubjectId;
        public string FirstName;
        public string LastName;
        public string Title;

        public Report()
        {
            StudentId = "";
            SubjectId = "";
            FirstName = "";
            LastName = "";
            Title = "";
        }

        public Report(string studentid, string firstName, string lastName, string subjectid, string title)
        {
            StudentId = studentid;
            SubjectId = subjectid;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
        }

    }
}
