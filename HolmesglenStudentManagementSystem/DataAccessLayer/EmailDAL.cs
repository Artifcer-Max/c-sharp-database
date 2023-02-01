using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class EmailDAL
    {
        private Microsoft.Data.Sqlite.SqliteConnection Connection;

        public EmailDAL(Microsoft.Data.Sqlite.SqliteConnection connection)
        {
            Connection = connection;
        }

        public List<Email> GetEmail(string id)
        {
            var email = new List<Email>();

            Connection.Open();
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT stu.FirstName, sub.Title, sub.SubjectID 
                FROM Student stu, Subject sub, Enrollment e
                where stu.StudentID = @a
                and stu.StudentID = e.StudentID_FK
                and e.SubjectID_FK = sub.SubjectID
            ";
            command.Parameters.AddWithValue("a", id);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var studentName = reader.GetString(0);
                var subjectTitle = reader.GetString(1);
                var subjectID = reader.GetString(2);
                email.Add(new Email(studentName, subjectTitle, subjectID));
            }

            Connection.Close();

            return email;
        }
    }

}
