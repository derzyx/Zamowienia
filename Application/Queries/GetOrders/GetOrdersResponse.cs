using Domain.Entities;

namespace Application.Queries.GetOrders
{
    public record GetOrdersResponse(ICollection<Order> Orders);
}