using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Data.Repository;
using Domain.Commands;
using Domain.Handlers;
using Domain.Models;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using static Domain.Queries.GetGenericQuery;

namespace API.CQRS.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IGenericRepository<Role> RoleRepository;

        private readonly IMapper _mapper;

        public RoleController(IGenericRepository<Role> RoleRepository, IMapper mapper)
        {
            this.RoleRepository = RoleRepository;
            this._mapper = mapper;

        }

        [HttpGet("GetRole")]
        public async Task<IEnumerable<Role>> GetRole() =>
            await (new GetListGenericHandler<Role>(RoleRepository)).Handle(new GetListGenericQuery<Role>(condition: null, includes: null), new CancellationToken());

        [HttpGet("GetRoleById")]
        public async Task<Role> GetRoleById(Guid id) =>
           await (new GetGenericHandler<Role>(RoleRepository)).Handle(new GetGenericQuery<Role>(condition: x => x.ID_Role.Equals(id), includes: null), new CancellationToken());

        [HttpPost("AddRole")]
        public async Task<Role> AddRole([FromBody] Role Role)
        {

            return await (new AddGenericHandler<Role>(RoleRepository)).Handle(new AddGenericCommand<Role>(Role), new CancellationToken());

        }

        [HttpPut("EditRole")]
        public async Task<String> EditRole([FromBody] Role Role)
        {
            return await (new PutGenericHandler<Role>(RoleRepository)).Handle(new PutGenericCommand<Role>(Role), new CancellationToken());

        }
        [HttpDelete("DeleteRole")]
        public async Task<String> DeleteRole(Guid id) =>
            await (new DeleteGenericHandler<Role>(RoleRepository)).Handle(new DeleteGenericCommand<Role>(id), new CancellationToken());



    }
}