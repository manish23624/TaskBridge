using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DashBoardDataRepository
{
   public interface IDashBoardRepository
    {
        HomeDashboardModel GetHomeDashboard();
    }
}
