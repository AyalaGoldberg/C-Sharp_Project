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
    public class SavingImages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; } // מאותחל אוטומטית
        private string orderCode;
        private Byte[] images;
        private int processorStatus;
        private int amount;

        public string OrderCode
        {
            get { return orderCode; }
            set { orderCode = value; }
        }
        public Byte[] Images
        {
            get { return images; }
            set { images = value; }
        }
        public int ProcessorStatus
        {
            get { return processorStatus; }
            set { processorStatus = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { processorStatus = value; }
        }

        public SavingImages(string _orderCode, Byte[] _images, int _processorStatus, int _amount)
        {
            OrderCode = _orderCode;
            Images = _images;
            ProcessorStatus = _processorStatus;
            Amount = _amount;
        }
        
        public SavingImages()
        {
            
        }
    }
}