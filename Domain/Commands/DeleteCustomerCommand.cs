using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Domain.Commands
{
    public class DeleteCustomerCommand<TEntity> : IRequest<String> where TEntity : class
    {
        public DeleteCustomerCommand(String id)
        {
            Id = id;
        }

        public String Id { get; }
    }
}
