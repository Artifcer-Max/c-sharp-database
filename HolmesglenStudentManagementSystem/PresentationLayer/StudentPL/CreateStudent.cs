using System;
using HolmesglenStudentManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using HolmesglenStudentManagementSystem.EntityModels;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class CreateStudent : PLBase
    {
        static private AppDBContext db;
        public override void Run()
        {
            db = new AppDBContext();
            var studentBll = new EntityStudentBLL(db);
            Console.WriteLine("Creating a new student");
            Console.Write("Enter ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            studentBll.Create(new EntityStudent()
            {
                StudentID = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            });
        }
    }
}
