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
    public class ProjetController : ControllerBase
    {
        private readonly IGenericRepository<Projet> ProjetRepository;

        private readonly IMapper _mapper;

        public ProjetController(IGenericRepository<Projet> ProjetRepository, IMapper mapper)
        {
            this.ProjetRepository = ProjetRepository;
            this._mapper = mapper;

        }

        [HttpGet("GetProjet")]
        public async Task<IEnumerable<Projet>> GetProjet() =>
            await (new GetListGenericHandler<Projet>(ProjetRepository)).Handle(new GetListGenericQuery<Projet>(condition: null, includes: null), new CancellationToken());

        [HttpGet("GetProjetById")]
        public async Task<Projet> GetProjetById(Guid id) =>
           await (new GetGenericHandler<Projet>(ProjetRepository)).Handle(new GetGenericQuery<Projet>(condition: x => x.ID_Projet.Equals(id), includes: null), new CancellationToken());

        [HttpPost("AddProjet")]
        public async Task<Projet> AddProjet([FromBody] Projet Projet)
        {

            return await (new AddGenericHandler<Projet>(ProjetRepository)).Handle(new AddGenericCommand<Projet>(Projet), new CancellationToken());

        }

        [HttpPut("EditProjet")]
        public async Task<String> EditPerson([FromBody] Projet Projet)
        {
            return await (new PutGenericHandler<Projet>(ProjetRepository)).Handle(new PutGenericCommand<Projet>(Projet), new CancellationToken());

        }
        [HttpDelete("DeleteProjet")]
        public async Task<String> DeletePerson(Guid id) =>
            await (new DeleteGenericHandler<Projet>(ProjetRepository)).Handle(new DeleteGenericCommand<Projet>(id), new CancellationToken());



    }
}