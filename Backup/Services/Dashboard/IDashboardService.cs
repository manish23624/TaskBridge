using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Dashboard
{
    interface IDashboardService
    {
        HomeDashboardModel GetHomeDashboard();
    }
}
