using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.EntityModels;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class DeleteStudent : PLBase
    {
        static private AppDBContext db;
        public override void Run()
        {
            db = new AppDBContext();
            Console.WriteLine("Deleting a student");
            Console.Write("Student ID: ");
            var id = Console.ReadLine();

            var studentBLL = new EntityStudentBLL(db);
            var result = studentBLL.Delete(id);
            if (result == false)
            {
                Console.WriteLine($"Delete student unsuccessful");
            }
            else
            {
                Console.WriteLine($"Delete student successful");
            }
        }
    }
}
