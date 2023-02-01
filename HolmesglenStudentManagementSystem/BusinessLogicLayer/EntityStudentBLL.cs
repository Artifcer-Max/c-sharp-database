using HolmesglenStudentManagementSystem.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class EntityStudentBLL
    {
        private AppDBContext db;
        public EntityStudentBLL(AppDBContext appDBContext)
        {
            this.db = appDBContext;
        }
        public List<EntityStudent> ReadAll()
        {
            var students = db.Student.ToList();
            return students;
        }

        public EntityStudent Read(string id)
        {
            EntityStudent student = db.Student.Find(id);

            return student;
        }

        public bool Create(EntityStudent student)
        {
            if (db.Student.Find(student.StudentID) == null)
            {
                db.Student.Add(student);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(EntityStudent student)
        {
            var studentToUpdate = db.Student.Find(student.StudentID);
            if (studentToUpdate == null)
            {
                return false;
            }
            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.Email = student.Email;
            db.SaveChanges();
            return true;
        }
        public bool Delete(String id)
        {
            var student = db.Student.Find(id);
            if (student == null)
            {
                return false;
            }
            db.Student.Remove(student);
            db.SaveChanges();
            return true;
        }

    }
}