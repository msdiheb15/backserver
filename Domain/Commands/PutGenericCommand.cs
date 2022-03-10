using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Domain.Commands
{
    public class PutGenericCommand<TEntity> : IRequest<String> where TEntity : class
    {
        public PutGenericCommand(TEntity entity)
        {
            Entity = entity;
        }

        public TEntity Entity { get; }

    }
}
