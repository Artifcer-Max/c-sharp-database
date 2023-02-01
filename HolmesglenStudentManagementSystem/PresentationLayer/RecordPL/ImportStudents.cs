using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.Models;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;

namespace HolmesglenStudentManagementSystem.PresentationLayer.RecordPL
{
    public class ImportStudents : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Please input path directory for the csv file you would like you upload:");
            var path = Console.ReadLine();
            Console.WriteLine("Getting file ready for Import");



            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Record>();
                var recordBLL = new RecordBLL();
                foreach (var record in records)
                {
                    
                    var result = recordBLL.Create(record);
                }
            }
            Console.WriteLine("Data Imported Successfully");
            
        }
    }
}
