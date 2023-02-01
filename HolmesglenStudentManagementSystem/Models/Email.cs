using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.Models
{
    public class Email
    {
        public string FirstName;
        public string SubjectId;
        public string Title;

        public Email()
        {
            FirstName = "";
            SubjectId = "";
            Title = "";
        }

        public Email(string firstName, string title, string subjectId)
        {
            FirstName = firstName;            
            Title = title;
            SubjectId = subjectId;
        }
    }
}
