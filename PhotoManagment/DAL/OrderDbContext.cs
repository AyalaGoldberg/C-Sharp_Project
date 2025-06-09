using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Officer> Officer { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<SavingImages> SavingImages { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<OrderManagement> OrderManagement { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                optionsBuilder.UseSqlServer("Server = DESKTOP-4G5A9E; Database = DB_PhotoManagement; Trusted_Connection = True; Encryptm = False");
            }
        }
        public OrderDbContext() { }
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }
        //public void AddCustomer(Customers customer)
        //{
        //    using (var context = new OrderDbContext())
        //    {
        //        context.Customers.Add(customer);
        //        context.SaveChanges();
        //    }
        //}

        //public void AddOfficer(Officer officer)
        //{
        //    using (var context = new OrderDbContext())
        //    {
        //        context.Officer.Add(officer);
        //        context.SaveChanges();
        //    }
        //}

        //public void AddOrderManagement(OrderManagement order)
        //{
        //    using (var context = new OrderDbContext())
        //    {
        //        context.OrderManagement.Add(order);
        //        context.SaveChanges();
        //    }
        //}

        //public void AddSavingImages(SavingImages image)
        //{
        //    using (var context = new OrderDbContext())
        //    {
        //        context.SavingImages.Add(image);
        //        context.SaveChanges();
        //    }
        //}

        //public void AddStatus(Status status)
        //{
        //    using (var context = new OrderDbContext())
        //    {
        //        context.Status.Add(status);
        //        context.SaveChanges();
        //    }
        //}

        public void AddEntity<T>(T entity) where T : class
        {
            using (var context = new OrderDbContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges(); // שמירה למסד הנתונים
            }
        }


    }
}