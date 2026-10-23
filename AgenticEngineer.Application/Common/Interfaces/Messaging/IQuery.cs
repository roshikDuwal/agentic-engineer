using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgenticEngineer.Application.Common.Interfaces.Messaging
{
    public interface IQuery<TResponse>:IRequest<TResponse>
    {
    }
}
