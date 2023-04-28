using Application.IRepositories;
using Application.Queries.GetOrders;
using Domain.Entities;
using Infrastructure.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries.GetOrders
{
    internal class GetOrdersHandler : IRequestHandler<GetOrdersQuery, GetOrdersResponse>
    {
        private readonly IFileManager _fileReader;
        private readonly IOrderRepository _orderRepository;

        public GetOrdersHandler(IFileManager fileReader, IOrderRepository orderRepository)
        {
            _fileReader = fileReader;
            _orderRepository = orderRepository;
        }

        public async Task<GetOrdersResponse> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = _fileReader.ReadCSV();

            var ordersFiltered = new GetOrdersResponse(_orderRepository.ApplyFilters(orders, request.filters));

            return ordersFiltered;
        }
    }
}
