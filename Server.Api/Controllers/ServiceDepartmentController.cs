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
    public class ServiceDepartmentController : ControllerBase
    {
        private readonly IGenericRepository<ServiceDepartment> ServiceDepartmentRepository;

        private readonly IMapper _mapper;

        public ServiceDepartmentController(IGenericRepository<ServiceDepartment> ServiceDepartmentRepository, IMapper mapper)
        {
            this.ServiceDepartmentRepository = ServiceDepartmentRepository;
            this._mapper = mapper;

        }

        [HttpGet("GetServiceDepartment")]
        public async Task<IEnumerable<ServiceDepartment>> GetServiceDepartment() =>
            await (new GetListGenericHandler<ServiceDepartment>(ServiceDepartmentRepository)).Handle(new GetListGenericQuery<ServiceDepartment>(condition: null, includes: null), new CancellationToken());

        [HttpGet("GetServiceDepartmentById")]
        public async Task<ServiceDepartment> GetServiceDepartmentById(Guid id) =>
           await (new GetGenericHandler<ServiceDepartment>(ServiceDepartmentRepository)).Handle(new GetGenericQuery<ServiceDepartment>(condition: x => x.ID_ServiceDepartment.Equals(id), includes: null), new CancellationToken());

        [HttpPost("AddServiceDepartment")]
        public async Task<ServiceDepartment> AddServiceDepartment([FromBody] ServiceDepartment ServiceDepartment)
        {

            return await (new AddGenericHandler<ServiceDepartment>(ServiceDepartmentRepository)).Handle(new AddGenericCommand<ServiceDepartment>(ServiceDepartment), new CancellationToken());

        }

        [HttpPut("EditServiceDepartment")]
        public async Task<String> EditServiceDepartment([FromBody] ServiceDepartment ServiceDepartment)
        {
            return await (new PutGenericHandler<ServiceDepartment>(ServiceDepartmentRepository)).Handle(new PutGenericCommand<ServiceDepartment>(ServiceDepartment), new CancellationToken());

        }
        [HttpDelete("DeleteServiceDepartment")]
        public async Task<String> DeleteServiceDepartment(Guid id) =>
            await (new DeleteGenericHandler<ServiceDepartment>(ServiceDepartmentRepository)).Handle(new DeleteGenericCommand<ServiceDepartment>(id), new CancellationToken());



    }
}