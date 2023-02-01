using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.EntityModels;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class GetOneStudent : PLBase
    {
        static private AppDBContext db;
        public override void Run()
        {
            db = new AppDBContext();
            var studentBLL = new EntityStudentBLL(db);
            Console.WriteLine("Getting a student");
            Console.Write("Student ID: ");
            var id = Console.ReadLine();
            var result = studentBLL.Read(id);
            Console.WriteLine($"{result.StudentID}\t{result.FirstName}\t{result.LastName}\t{result.Email}");
        }
    }
}
