using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgenticEngineer.Application.Common.Interfaces.Messaging
{
    public interface IQueryHandler<TQuery, TResponse>:IRequestHandler<TQuery, TResponse> where TQuery:IQuery<TResponse>
    {
    }
}
