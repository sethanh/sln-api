using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Sln.Shared.Common.Interfaces
{
    public interface IEventRequest : INotification { }
    public interface IEventRequest<T> : IEventRequest
    {
        T Data { get; set; }
    }
}