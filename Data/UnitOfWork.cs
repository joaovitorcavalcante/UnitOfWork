﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitOfShop.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }

    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            
        }
    }
}
