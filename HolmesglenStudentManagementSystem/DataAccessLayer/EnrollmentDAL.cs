using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class EnrollmentDAL
    {
        private Microsoft.Data.Sqlite.SqliteConnection Connection;

        // Establish a connection
        public EnrollmentDAL(Microsoft.Data.Sqlite.SqliteConnection connection)
        {
            Connection = connection;
        }

        // Create
        public void Create(Enrollment enrollment)
        {
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Enrollment
                (EnrollmentID, StudentID_FK, SubjectID_FK)
                VALUES(@a, @b, @c)
            ";

            command.Parameters.AddWithValue("a", enrollment.Id);
            command.Parameters.AddWithValue("b", enrollment.StudentId);
            command.Parameters.AddWithValue("c", enrollment.SubjectId);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        // Read
        public Enrollment Read(string id)
        {
            Enrollment enrollment = null;
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT EnrollmentID, StudentID_FK, SubjectID_FK
                FROM Enrollment
                WHERE EnrollmentID = @a
            ";
            command.Parameters.AddWithValue("a", id);


            // execute the query
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var enrollmentId = reader.GetString(0);
                var studentId = reader.GetString(1);
                var subjectId = reader.GetString(2);
                enrollment = new Enrollment(enrollmentId, studentId, subjectId);
            } // else enrollment = null

            Connection.Close();

            return enrollment;
        }

        // Read all
        public List<Enrollment> ReadAll()
        {
            var enrollment = new List<Enrollment>();

            Connection.Open();

            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT *
                FROM Enrollment
            ";

            // execute the query
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var enrollmentId = reader.GetString(0);
                var studentId = reader.GetString(1);
                var subjectId = reader.GetString(2);
                enrollment.Add(new Enrollment(enrollmentId, studentId, subjectId));
            }
            Connection.Close();
            return enrollment;
        }
        // Update
        public void Update(Enrollment enrollment)
        {
            Connection.Open();
            // build the query
            var command = Connection.CreateCommand();
            command.CommandText = @"
                UPDATE Enrollment
                SET StudentID_FK = @a,
                    SubjectID_FK = @b
                WHERE EnrollmentID = @c
            ";
            command.Parameters.AddWithValue("a", enrollment.StudentId);
            command.Parameters.AddWithValue("b", enrollment.SubjectId);
            command.Parameters.AddWithValue("c", enrollment.Id);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }
        // Delete
        public void Delete(string id)
        {
            
            Connection.Open();
            // build the query
            var command = Connection.CreateCommand();
            command.CommandText = @"
                DELETE FROM Enrollment
                WHERE EnrollmentID = @a
            ";
            command.Parameters.AddWithValue("a", id);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }
    }
}
    