using System;
using HolmesglenStudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class CreateEnrollment : PLBase
    {
        public override void Run()
        {
            var enrollment = new Enrollment();
            Console.WriteLine("Creating a new enrollment");
            Console.Write("Enter ID: ");
            enrollment.Id = Console.ReadLine();
            Console.Write("Enter Student ID: ");
            enrollment.StudentId = Console.ReadLine();
            Console.Write("Enter Subject ID: ");
            enrollment.SubjectId = Console.ReadLine();

            var enrollmentBLL = new EnrollmentBLL();
            var result = enrollmentBLL.Create(enrollment);

            if (result == false)
            {
                Console.WriteLine($"Create new enrollment unsuccessful");
            }
            else
            {
                Console.WriteLine($"Create new enrollment successful");
            }
        }
    }
}
