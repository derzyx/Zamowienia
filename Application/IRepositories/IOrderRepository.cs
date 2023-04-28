using Common.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IOrderRepository
    {
        public ICollection<Order> ApplyFilters(List<Order> orders, Filter filters);
    }
}
