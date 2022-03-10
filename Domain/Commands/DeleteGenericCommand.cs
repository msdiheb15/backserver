﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Domain.Commands
{
    public class DeleteGenericCommand<TEntity> : IRequest<String> where TEntity : class
    {
        public DeleteGenericCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
