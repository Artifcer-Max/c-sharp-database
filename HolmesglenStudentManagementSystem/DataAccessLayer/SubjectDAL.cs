using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class SubjectDAL
    {        
        private Microsoft.Data.Sqlite.SqliteConnection Connection;

        public SubjectDAL(Microsoft.Data.Sqlite.SqliteConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }
        // Create Command
        public void Create(Subject subject)
        {
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Subject
                (SubjectID, Title, NumberOfSession, HourPerSession)
                VALUES(@a, @b, @c, @d)
            ";

            command.Parameters.AddWithValue("a", subject.Id);
            command.Parameters.AddWithValue("b", subject.Title);
            command.Parameters.AddWithValue("c", subject.NumberOfSession);
            command.Parameters.AddWithValue("d", subject.HourPerSession);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }
        // Read Command
        public Subject Read(string id)
        {
            Subject subject = null;
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT SubjectID, Title, NumberOfSession, HourPerSession
                FROM Subject
                WHERE SubjectId = @a            
            ";
            command.Parameters.AddWithValue("a", id);

            // execute the reader
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var subjectid = reader.GetString(0);
                var subjecttitle = reader.GetString(1);
                var subjectnum = reader.GetString(2);
                var subjecthour = reader.GetString(3);
                subject = new Subject(subjectid, subjecttitle, subjectnum, subjecthour);
            }

            Connection.Close();

            return subject;
        }

        // Read all Command
        public List<Subject> ReadAll()
        {
            var subjects = new List<Subject>();

            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT *
                FROM Subject
            ";
            // execute the reader
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var subjectid = reader.GetString(0);
                var subjecttitle = reader.GetString(1);
                var subjectnum = reader.GetString(2);
                var subjecthour = reader.GetString(3);
                subjects.Add(new Subject(subjectid, subjecttitle, subjecthour, subjectnum));
            }
            Connection.Close();

            return subjects;
        }
        // Update Command
        public void Update(Subject subject)
        {
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                UPDATE Subject
                SET Title = @a,
                    NumberOfSession = @b,
                    HourPerSession = @c
                Where SubjectID = @d
            ";
            command.Parameters.AddWithValue("a", subject.Title);
            command.Parameters.AddWithValue("b", subject.NumberOfSession);
            command.Parameters.AddWithValue("c", subject.HourPerSession);
            command.Parameters.AddWithValue("d", subject.Id);
            // execute the reader
            command.ExecuteReader();

            Connection.Close();            
        }
        // Delete Command
        public void Delete(string id)
        {
            Connection.Open();
            // build ther query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                DELETE FROM Subject
                Where SubjectID = @a
            ";
            command.Parameters.AddWithValue("a", id);
            // execute the reader
            command.ExecuteReader();

            Connection.Close();
            
        }
    }
}
