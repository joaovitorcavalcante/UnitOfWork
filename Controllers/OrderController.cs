using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfShop.Data;
using UnitOfShop.Models;
using UnitOfShop.Repositories;

namespace UnitOfShop.Controllers
{
    [ApiController]
    [Route("v1/orders")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public Order Store(
            [FromServices] ICustomerRepository customerRepository,
            [FromServices] IOrderRepository orderRepository,
            [FromServices] IUnitOfWork uow
        )
        {
            try
            {
                var customer = new Customer { Name = "João Vitor" };
                var order = new Order { Number = "123", Customer = customer };

                customerRepository.Save(customer);
                orderRepository.Save(order);

                uow.Commit();

                return order;
            } catch
            {
                uow.Rollback();
                return null;
            }
        }
    }
}
