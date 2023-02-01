using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class RecordBLL
    {
        AppDAL appDAL;

        public RecordBLL()
        {
            appDAL = new AppDAL();
        }

        public List<Record> GetAll()
        {
            return appDAL.RecordDALInstance.ReadAll();

        }
        public bool Create(Record record)
        {
            appDAL.RecordDALInstance.Create(record);
            
            return true;
        }
    }
}
