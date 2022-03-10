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
    public class PersonController : ControllerBase
    {
        private readonly IGenericRepository<Person> PersonRepository;

        private readonly IMapper _mapper;

        public PersonController(IGenericRepository<Person> PersonRepository, IMapper mapper)
        {
            this.PersonRepository = PersonRepository;
            this._mapper = mapper;

        }

        [HttpGet("GetPerson")]
        public async Task<IEnumerable<Person>> GetPerson() =>
            await (new GetListGenericHandler<Person>(PersonRepository)).Handle(new GetListGenericQuery<Person>(condition: null, includes: null), new CancellationToken());

        [HttpGet("GetPersonById")]
        public async Task<Person> GetPersonById(Guid id) =>
           await (new GetGenericHandler<Person>(PersonRepository)).Handle(new GetGenericQuery<Person>(condition: x => x.ID_person.Equals(id), includes: null), new CancellationToken());

        [HttpGet("GetPersonByService")]
        public async Task<IEnumerable<Person>> GetPersonByService(Guid fk_service) =>
           await (new GetListGenericHandler<Person>(PersonRepository)).Handle(new GetListGenericQuery<Person>(condition: x => x.FK_ServiceDepartment.Equals(fk_service), includes: null), new CancellationToken());

        [HttpPost("AddPerson")]
        public async Task<Person> AddPerson([FromBody] Person Person)
        {

            return await (new AddGenericHandler<Person>(PersonRepository)).Handle(new AddGenericCommand<Person>(Person), new CancellationToken());

        }

        [HttpPut("EditPerson")]
        public async Task<String> EditPerson([FromBody] Person Person)
        {
            return await (new PutGenericHandler<Person>(PersonRepository)).Handle(new PutGenericCommand<Person>(Person), new CancellationToken());

        }
        [HttpDelete("DeletePerson")]
        public async Task<String> DeletePerson(Guid id) =>
            await (new DeleteGenericHandler<Person>(PersonRepository)).Handle(new DeleteGenericCommand<Person>(id), new CancellationToken());



    }
}