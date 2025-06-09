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
    public class Officer : IRepository<Officer>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; } // מאותחל אוטומטית
        private string officerCode;
        private string name;
        private string phone;
        public string OfficerCode 
        {
            get { return officerCode; } 
            set { officerCode = value; } 
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
        public Officer (string _officerCode, string _name, string _phone)
        {
            OfficerCode = _officerCode;
            Name = _name;
            Phone = _phone;
        }
        public Officer() { }
        public void Add(OrderDbContext context)
        {
            context.Officer.Add(this);
            context.SaveChanges();
        }
    }
}