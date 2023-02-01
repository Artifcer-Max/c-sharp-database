using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;
using Microsoft.Data.Sqlite;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class EmailBLL
    {
        AppDAL appDAL;

        public EmailBLL()
        {
            appDAL = new AppDAL();
        }
        public List<Email> GenerateEmail(string id)
        {
            return appDAL.EmailDALInstance.GetEmail(id);
        }
    }
}
