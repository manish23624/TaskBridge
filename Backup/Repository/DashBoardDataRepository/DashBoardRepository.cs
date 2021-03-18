using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repository.DashBoardDataRepository
{
    public sealed class DashBoardRepository : IDashBoardRepository
    {
        private DashBoardRepository()
        {

        }
       public HomeDashboardModel GetHomeDashboard()
        {
            HomeDashboardModel emp = new HomeDashboardModel();
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.DBConn, CommandType.StoredProcedure, "HomeDashboard");
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    emp.TotalCase = Convert.ToInt32(dt.Rows[0]["Total"].ToString());
                    emp.PendingCase = Convert.ToInt32(dt.Rows[0]["pending"].ToString());
                    emp.DisposedCase = Convert.ToInt32(dt.Rows[0]["Disposed"].ToString());
                    emp.MonthTotal = Convert.ToInt32(dt.Rows[0]["MonthTotal"].ToString());
                    emp.ActiveCourts = Convert.ToInt32(dt.Rows[0]["ActiveCourts"].ToString());
                }
                return emp;
            }
            catch (Exception ex)
            {
                throw ex;
                //helper.insert_AuditLog("Login", "DashboardCount", loginid, DateTime.Now, myIP, ex.Message.ToString());
            }
        }
    }
}
