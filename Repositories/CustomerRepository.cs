using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfShop.Data;
using UnitOfShop.Models;

namespace UnitOfShop.Repositories
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            this._context = context;
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
        }
    }
}
