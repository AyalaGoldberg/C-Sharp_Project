﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
        public interface IRepository<T> where T : class 
        { 
            void Add(OrderDbContext context);
        }
}
