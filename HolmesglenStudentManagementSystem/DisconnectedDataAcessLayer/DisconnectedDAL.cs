using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using HolmesglenStudentManagementSystem.Models;

namespace HolmesglenStudentManagementSystem.DisconnectedDataAccessLayer
{
    public class DisconnectedDAL
    {
        private SQLiteConnection Connection;

        private SQLiteDataAdapter DataAdapter;

        private DataSet DBDataSet;

        private string DBQueryString = @"
        SELECT *
        FROM Student
        ";

        public DisconnectedDAL(string connectionString)
        {
            Connection = new SQLiteConnection(connectionString);

            DataAdapter = new SQLiteDataAdapter(DBQueryString, Connection);

            DBDataSet = new DataSet();
            DataAdapter.Fill(DBDataSet);

            DBDataSet.Tables[0].TableName = "Student";

        }

        public List<Student> StudentReadAll()
        {
            var students = new List<Student>();
            foreach (DataRow row in DBDataSet.Tables["Student"].Rows)
            {
                var id = row["StudentID"].ToString();
                var firstName = row["FirstName"].ToString();
                var lastName = row["LastName"].ToString();
                var email = row["Email"].ToString();
                students.Add(new Student(id, firstName, lastName, email));
            }
            return students;
        }
    }

}
