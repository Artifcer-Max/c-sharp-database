using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.EntityModels
{
    public class EntityEnrollment
    {
        public int Id { get; set; }
        public string StudentID_FK { get; set; }
        public string SubjectID_FK { get; set; }

    }
}
