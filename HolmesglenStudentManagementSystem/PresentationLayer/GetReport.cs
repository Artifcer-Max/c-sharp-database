using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer
{
    public class GetReport : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Getting Enrollment Report Details");

            var reportBLL = new ReportBLL();
            var result = reportBLL.Report();
            if (result.Count == 0)
            {
                Console.WriteLine("There is not data for report");
            }
            else
            {
                Console.WriteLine($"|\tStudentID\tFirstname\tLastname\tSubjectID\tTitle");
                Console.WriteLine($"----------------------------------------------------------------------------------");
                foreach (var item in result)
                {
                    Console.WriteLine($"|\t{item.StudentId}\t|\t{item.FirstName}\t|\t{item.LastName}\t|\t{item.SubjectId}\t|\t{item.Title}");
                    Console.WriteLine($"----------------------------------------------------------------------------------");
                }
            }
        }

    }
}
