using Application.IRepositories;
using Common.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public ICollection<Order> ApplyFilters(List<Order> orders, Filter filters)
        {
            // Order number
            if (filters.Number != null)
            {
                orders = orders.Where(x => x.Number == filters.Number).ToList();
            }

            // Dates
            if(filters.DateFrom != DateTime.MinValue && filters.DateTo != DateTime.MinValue)
            {
                if(filters.DateFrom > filters.DateTo)
                {
                    orders = orders.Where(x => x.OrderDate >= filters.DateFrom && x.OrderDate <= filters.DateTo).ToList();
                }
            }

            // Clients
            if (filters.ClientNames.Any())
            {
                orders = orders.Where(x => filters.ClientNames.Contains(x.ClientName)).ToList();
            }

            return orders;
        }
    }
}
