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
    public class DeleteGenericHandler<TEntity> : IRequestHandler<DeleteGenericCommand<TEntity>, String> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> Repository;
        public DeleteGenericHandler(IGenericRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }
        public Task<String> Handle(DeleteGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var result = Repository.Delete(request.Id);
            return Task.FromResult(result);
        }
    }
}
