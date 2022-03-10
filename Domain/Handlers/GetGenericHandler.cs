﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data.Repository;
using MediatR;
using static Domain.Queries.GetGenericQuery;

namespace Domain.Handlers
{
    public class GetGenericHandler<TEntity> : IRequestHandler<GetGenericQuery<TEntity>, TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> Repository;
        public GetGenericHandler(IGenericRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }

        public Task<TEntity> Handle(GetGenericQuery<TEntity> request, CancellationToken cancellationToken)
        {

            var result = Repository.Get(request.Condition, request.Includes);
            return Task.FromResult(result);
        }


    }
}
