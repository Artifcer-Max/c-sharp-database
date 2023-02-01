using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
     public class ReportBLL
    {
        AppDAL appDAL;
        public ReportBLL()
        {
            appDAL = new AppDAL();
        }
        public List<Report> Report()
        {
            return appDAL.ReportDALInstance.Report();
        }
        
    }
}
