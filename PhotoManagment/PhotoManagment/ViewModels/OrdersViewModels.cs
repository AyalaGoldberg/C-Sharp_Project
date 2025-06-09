using DAL;
using Microsoft.AspNetCore.Mvc;
using PhotoManagment.Models;
using System.Collections.Generic;

namespace PhotoManagment.ViewModels
{
    public class OrdersViewModels
    {

            public List<OrderManagement> Orders { get; set; } // רשימת ההזמנות
            public List<Status> Statuses { get; set; } // רשימת הסטטוסים
            public string SelectedOfficerCode { get; set; } // קוד הקצין הנבחר
    }

}
