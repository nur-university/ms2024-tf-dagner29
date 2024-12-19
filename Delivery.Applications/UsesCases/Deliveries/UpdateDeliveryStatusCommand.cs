﻿//using Delivery.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Delivery.Domain./*Deliveries*/;
using Delivery.Domain.Entities;
using Delivery.Domain.Interfaces;
using MediatR;

namespace Delivery.Applications.UsesCases.Deliveries
{

    public class UpdateDeliveryStatusCommand : IRequest
    {
        public Guid DeliveryId { get; set; }
        public string Status { get; set; }
    }


}
