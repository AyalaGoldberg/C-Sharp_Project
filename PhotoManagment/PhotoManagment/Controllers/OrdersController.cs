//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using DAL;
//using Microsoft.EntityFrameworkCore;
//using PhotoManagment.ViewModels;
//using PhotoManagment.Models;

//namespace PhotoManagment.Controllers
//{
//    //[Route("api/[controller]")]
//    [Route("orders")]
//    public class OrdersController : Controller
//    {
//        private readonly OrderDbContext _context; // משתנה פרטי לשמירת ההקשר של בסיס הנתונים

//        // קונסטרוקטור שמקבל את ההקשר של בסיס הנתונים
//        public OrdersController(OrderDbContext context) => _context = context; // אתחול המשתנה הפרטי עם ההקשר שהתקבל
//        [HttpGet("orderlist")]

//        public IActionResult OrderList()
//        {
//            // פעולות להחזרת הרשימה
//            return View("OrderList");
//        }

//        // פעולה שמחזירה את התצוגה של רשימת ההזמנות
//        //[Route("Orders/Index")]
//        [HttpGet("Index")]
//        public IActionResult Index(string officerCode)
//        {
//            var orders = _context.OrderManagement
//                .Where(o => o.OfficerCode == officerCode)
//                .ToList();

//            var statuses = _context.Status.ToList();

//            var viewModel = new OrdersViewModels
//            {
//                Orders = orders,
//                Statuses = statuses,
//                SelectedOfficerCode = officerCode
//            };

//            return View(viewModel);
//        }

//        [Route("Orders/UpdateStatus")]
//        [HttpPost("UpdateStatus")]
//        public IActionResult UpdateStatus(int orderId, int newStatusId)
//        {
//            var order = _context.OrderManagement.Find(orderId);
//            if (order != null)
//            {
//                order.ProcessStatus = newStatusId;
//                _context.SaveChanges();
//                return RedirectToAction("Index", new { officerCode = order.OfficerCode });
//            }
//            // במקרה שההזמנה לא נמצאה, כדאי להחזיר הודעת שגיאה או לפנות לדף אחר
//            return NotFound();
//        }
//        [Route("Orders/Login")]
//        [HttpPost("Login")]
//        public IActionResult Login(LoginModel model)
//        {
//            var officer = _context.Officer.FirstOrDefault(o => o.OfficerCode == model.OfficerCode);
//            if (officer != null)
//            {
//                var orders = _context.OrderManagement.Where(o => o.OfficerCode == officer.OfficerCode).ToList();
//                var viewModel = new OrdersViewModels
//                {
//                    Orders = orders,
//                    Statuses = _context.Status.ToList(),
//                    SelectedOfficerCode = officer.OfficerCode
//                };
//                //return View("OrdersList", viewModel);
//                return RedirectToAction("Index", new { officerCode = officer.OfficerCode });

//            }
//            return View("Login");


//        }



//    }
//}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Microsoft.EntityFrameworkCore;
using PhotoManagment.ViewModels;
using PhotoManagment.Models;

namespace PhotoManagment.Controllers
{
    [Route("orders")]
    public class OrdersController : Controller
    {
        private readonly OrderDbContext _context;

        public OrdersController(OrderDbContext context) => _context = context;

        [HttpGet("orderlist")]
        public IActionResult OrderList()
        {
            return View("OrderList");
        }

        [HttpGet("index")]
        public IActionResult Index(string officerCode)
        {
            var orders = _context.OrderManagement
                .Where(o => o.OfficerCode == officerCode)
                .ToList();

            var statuses = _context.Status.ToList();

            var viewModel = new OrdersViewModels
            {
                Orders = orders,
                Statuses = statuses,
                SelectedOfficerCode = officerCode
            };

            return View(viewModel);
        }

        [HttpPost("updatestatus")]
        [ValidateAntiForgeryToken] // הוספת הגנה מפני CSRF
        public IActionResult UpdateStatus(int orderId, int newStatusId)
        {
            var order = _context.OrderManagement.Find(orderId); // מוצא את ההזמנה לפי מזהה
            if (order != null)
            {
                order.ProcessStatus = newStatusId; // מעדכן את הסטטוס של ההזמנה
                _context.SaveChanges(); // שומר את השינויים בבסיס הנתונים
                return RedirectToAction("Index", new { officerCode = order.OfficerCode }); // מפנה לאינדקס
            }
            // מחזיר הודעת שגיאה אם ההזמנה לא נמצאה
            return NotFound("ההזמנה לא נמצאה."); // הוספת הודעת שגיאה
        }

        [HttpPost("OrderList")]
        [ValidateAntiForgeryToken] // הוספת הגנה מפני CSRF
        public IActionResult Login(LoginModel model)
        {
            var officer = _context.Officer.FirstOrDefault(o => o.OfficerCode == model.OfficerCode);
            if (officer != null)
            {
                var orders = _context.OrderManagement.Where(o => o.OfficerCode == officer.OfficerCode).ToList();
                var viewModel = new OrdersViewModels
                {
                    Orders = orders,
                    Statuses = _context.Status.ToList(),
                    SelectedOfficerCode = officer.OfficerCode
                };
                return RedirectToAction("Index", new { officerCode = officer.OfficerCode });
            }
            // הוספת הודעת שגיאה במקרה של כניסה לא מוצלחת
            ModelState.AddModelError("", "קוד קצין שגוי."); // הוספת הודעת שגיאה
            return View("OrderList", model);
        }
    }
}
