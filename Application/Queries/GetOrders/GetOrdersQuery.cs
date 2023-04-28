﻿using Common.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetOrders
{
    public record GetOrdersQuery(Filter filters) : IRequest<GetOrdersResponse>;
}
