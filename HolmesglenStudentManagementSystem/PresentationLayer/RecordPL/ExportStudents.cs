using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using Microsoft.Data.Sqlite;
using CsvHelper;
using System.Globalization;
using HolmesglenStudentManagementSystem.Models;

namespace HolmesglenStudentManagementSystem.PresentationLayer.RecordPL
{
    public class ExportStudents : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Grabbing students for export");
            var recordBLL = new RecordBLL();
            var result = recordBLL.GetAll();
            using (var writer = new StreamWriter(@"C:\Users\saint\Downloads\data-driven-at2-202220\CSV\Export.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(result);



            }
        }
    }
}
