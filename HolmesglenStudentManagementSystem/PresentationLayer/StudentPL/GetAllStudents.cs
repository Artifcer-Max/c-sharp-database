using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.EntityModels;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class GetAllStudents : PLBase
    {
        static private AppDBContext db;
        public override void Run()
        {
             Console.WriteLine("Getting all students");

            db = new AppDBContext();
            var studentBll = new EntityStudentBLL(db);

            var result = studentBll.ReadAll();

            foreach (var record in result)
            {
                Console.WriteLine($"{record.StudentID}\t{record.FirstName}\t{record.LastName}\t{record.Email}");
            }

        }
    }
}
