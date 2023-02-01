using System;
using HolmesglenStudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class CreateSubject : PLBase
    {
        public override void Run()
        {
            var subject = new Subject();
            Console.WriteLine("Creating a new subject");
            Console.Write("Enter ID: ");
            subject.Id = Console.ReadLine();
            Console.Write("Enter Subject Title: ");
            subject.Title = Console.ReadLine();
            Console.Write("Enter # of sessions: ");
            subject.NumberOfSession = Console.ReadLine();
            Console.Write("Enter # of hours per session: ");
            subject.HourPerSession = Console.ReadLine();

            var subjectBLL = new SubjectBLL();
            var result = subjectBLL.Create(subject);

            if (result == false)
            {
                Console.WriteLine($"Create new student unsuccessful");
            }
            else
            {
                Console.WriteLine($"Create new student successful");
            }
        }
    }
}
