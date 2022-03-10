using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Data.Repository;
using Domain.Commands;
using MediatR;

namespace Domain.Handlers
{
    public class PutGenericHandler<TEntity> : IRequestHandler<PutGenericCommand<TEntity>, String> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> Repository;
        public PutGenericHandler(IGenericRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }
        public Task<String> Handle(PutGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var result = Repository.Put(request.Entity);
            return Task.FromResult(result);
        }
    }
}
