using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Customers : IRepository<Customers>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; private set; } // מאותחל אוטומטית
        //private string customerCode;
        //private string name;
        //private string phone;
        //private string email;
        public int Id { get; private set; } // מאותחל אוטומטית
        public string customerCode;
        public string name;
        public string phone;
        public string email;
        public string CustomerCode
        {
            get { return customerCode; }
            set { customerCode = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Email
        {
            get { return email; } // מחזיר את כתובת האימייל
            set
            {
                // בדיקה אם כתובת האימייל תקינה
                if (!IsValidEmail(value))
                {
                    throw new ArgumentException("כתובת האימייל אינה תקינה"); // זורק שגיאה אם האימייל לא תקין
                }
                email = value; // אם תקין, מאחסן את כתובת האימייל
            }
        }
        public Customers(string _customerCode, string _name, string _phone, string _email)
        {
            CustomerCode = _customerCode;
            Name = _name;
            Phone = _phone;
            email = _email;
        }
        public Customers() { }

        public void Add(OrderDbContext context)
        {
            context.Customers.Add(this);
            context.SaveChanges();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                // מנסה ליצור אובייקט MailAddress מהכתובת
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email; // מחזיר true אם הכתובת תקינה
            }
            catch
            {
                return false; // מחזיר false אם הייתה שגיאה, כלומר הכתובת לא תקינה
            }
        }
    }
}
