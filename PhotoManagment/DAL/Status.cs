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
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; } // מאותחל אוטומטית
        private int processStatus;
        private string statusDescription;

        public int ProcessStatus
        {
            get { return processStatus; }
            set { processStatus = value; }
        }
        public string StatusDescription
        {
            get { return statusDescription; }
            set { statusDescription = value; }
        }

        public Status (int _processStatus, string _statusDescription)
        {
            ProcessStatus = _processStatus;
            StatusDescription = _statusDescription;
        }
    }
}