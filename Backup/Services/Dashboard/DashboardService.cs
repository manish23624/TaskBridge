using Models;
using Repository.DashBoardDataRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Dashboard
{
   public class DashboardService : IDashboardService
    {
        IDashBoardRepository _dashBoardRepository;

        public DashboardService(IDashBoardRepository dashBoardRepository)
        {
            _dashBoardRepository = dashBoardRepository;
        }
        public HomeDashboardModel GetHomeDashboard()
        {
            return _dashBoardRepository.GetHomeDashboard();
        }
    }
}
