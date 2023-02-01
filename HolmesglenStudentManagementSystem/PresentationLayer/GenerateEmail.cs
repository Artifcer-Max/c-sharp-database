using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;

namespace HolmesglenStudentManagementSystem.PresentationLayer
{
    public class GenerateEmail : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Generating Email");
            Console.WriteLine("Enter Student ID");            
            var id = Console.ReadLine();
            Console.WriteLine("------------------------------------------------------------------------");

            var emailBLL = new EmailBLL();
            var email = emailBLL.GenerateEmail(id);
            if(email.Count == 0)
            {
                Console.WriteLine($"Student {id} does not have any enrollment details. Please enter an enrolled student");
            }
            else
            {
                Console.WriteLine($"Dear {email[0].FirstName},");                
                Console.WriteLine("");
                Console.WriteLine("You have been enrolled in the following subjects:");
                foreach (var item in email)
                {
                    Console.WriteLine($"> {item.Title} ({item.SubjectId})");
                }
                Console.WriteLine("Please login to your account and confirm the above enrollments.");
                Console.WriteLine("");
                Console.WriteLine("Regards,");
                Console.WriteLine("CAIT Department");
            }
        }
    }
}
