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
    public class OrderManagement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; } // מאותחל אוטומטית
        private string orderCode;
        private int processStatus;
        private string officerCode;
        private string customerCode;
        public DateTime OrderDate { get; set; }


        public string OrderCode 
        {
            get { return orderCode; }
            set 
            {
                if (orderCode != value && orderCode != null)
                {
                    orderCode = value;
                }
            }
        }
        public int ProcessStatus {
            get { return processStatus; }
            set
            {
                if (processStatus != value && processStatus != 0)
                {
                    processStatus = value;
                }
            } 
        }
        public string OfficerCode {
            get { return officerCode; }
            set
            {
                if (officerCode != value && officerCode != null)
                {
                    officerCode = value;
                }
            }
        }
        public string CustomerCode {
            get { return customerCode; }
            set {
                if (customerCode != value && customerCode != null)
                {
                    customerCode = value;
                }
            }
        }
        public OrderManagement() { }

        public OrderManagement(string _orderCode, int _processStatus, string _officerCode, string _customerCode, DateTime orderDate) 
        {
            OrderCode = _orderCode;
            ProcessStatus = _processStatus;
            OfficerCode = _officerCode;
            CustomerCode = _customerCode;
            OrderDate = orderDate;
        }
    }
}