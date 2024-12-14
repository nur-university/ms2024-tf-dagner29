﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Delivery.Domain.Abstractions
{
    public abstract record DomainEvent : INotification
    {
        public Guid Id { get; set; }
        public DateTime OccuredOn { get; set; }

        public DomainEvent()
        {
            Id = Guid.NewGuid();
            OccuredOn = DateTime.Now;
        }


    }
}
