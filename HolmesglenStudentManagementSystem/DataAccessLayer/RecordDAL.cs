using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.Models;
using Microsoft.Data.Sqlite;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class RecordDAL
    {
        private Microsoft.Data.Sqlite.SqliteConnection Connection;

        public RecordDAL(Microsoft.Data.Sqlite.SqliteConnection connection)
        {
            Connection = connection;
        }

        public List<Record> ReadAll()
        {
            var record = new List<Record>();

            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT StudentID, FirstName, LastName, Email
                FROM Student
            ";

            // execute the query

            var reader = command.ExecuteReader();



            while (reader.Read())
            {
                var studentId = reader.GetString(0);
                var studentFName = reader.GetString(1);
                var studentLName = reader.GetString(2);
                var studentEmail = reader.GetString(3);
                record.Add(new Record(studentId, studentFName, studentLName, studentEmail));
            }
            Connection.Close();
            return record;
        }
        public void Create(Record record)
        {
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Student
                (StudentID, FirstName, LastName, Email)
                VALUES(@a, @b, @c, @d)
            ";

            command.Parameters.AddWithValue("a", record.Id);
            command.Parameters.AddWithValue("b", record.FirstName);
            command.Parameters.AddWithValue("c", record.LastName);
            command.Parameters.AddWithValue("d", record.Email);

            try
            {
                // execute the query
                command.ExecuteReader();
            } catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            Connection.Close();
        }
    }
}
