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
    public class TacheController : ControllerBase
    {
        private readonly IGenericRepository<Tache> TacheRepository;

        private readonly IMapper _mapper;

        public TacheController(IGenericRepository<Tache> TacheRepository, IMapper mapper)
        {
            this.TacheRepository = TacheRepository;
            this._mapper = mapper;

        }

        [HttpGet("GetTache")]
        public async Task<IEnumerable<Tache>> GetTache() =>
            await (new GetListGenericHandler<Tache>(TacheRepository)).Handle(new GetListGenericQuery<Tache>(condition: null, includes: null), new CancellationToken());

        [HttpGet("GetTacheById")]
        public async Task<Tache> GetTacheById(Guid id) =>
           await (new GetGenericHandler<Tache>(TacheRepository)).Handle(new GetGenericQuery<Tache>(condition: x => x.ID_Taches.Equals(id), includes: null), new CancellationToken());

        [HttpPost("AddTache")]
        public async Task<Tache> AddTache([FromBody] Tache Tache)
        {

            return await (new AddGenericHandler<Tache>(TacheRepository)).Handle(new AddGenericCommand<Tache>(Tache), new CancellationToken());

        }

        [HttpPut("EditTache")]
        public async Task<String> EditTache([FromBody] Tache Tache)
        {
            return await (new PutGenericHandler<Tache>(TacheRepository)).Handle(new PutGenericCommand<Tache>(Tache), new CancellationToken());

        }
        [HttpDelete("DeleteTache")]
        public async Task<String> DeletePerson(Guid id) =>
            await (new DeleteGenericHandler<Tache>(TacheRepository)).Handle(new DeleteGenericCommand<Tache>(id), new CancellationToken());



    }
}