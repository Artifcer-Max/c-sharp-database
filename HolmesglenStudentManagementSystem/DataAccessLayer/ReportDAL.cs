using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.Models;
using Microsoft.Data.Sqlite;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class ReportDAL
    {
        private Microsoft.Data.Sqlite.SqliteConnection Connection;
        public ReportDAL(Microsoft.Data.Sqlite.SqliteConnection connection)
        {
            Connection = connection;
        }

        public List<Report> Report()
        {
            var report = new List<Report>();

            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT stu.StudentID, stu.FirstName, stu.LastName, sub.SubjectID, sub.Title 
                FROM Student stu, Subject sub, Enrollment e
                WHERE e.StudentID_FK = stu.StudentID
                and e.SubjectID_FK = sub.SubjectID
            ";

            // execute the query
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var studentId = reader.GetString(0);
                var studentFName = reader.GetString(1);
                var studentLName = reader.GetString(2);
                var subjectId = reader.GetString(3);
                var subjectTitle = reader.GetString(4);
                report.Add(new Models.Report(studentId, studentFName, studentLName, subjectId, subjectTitle));
            }

            Connection.Close();
            return report;
        }
    }
}
