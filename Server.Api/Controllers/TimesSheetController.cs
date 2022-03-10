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
    public class TimesSheetController : ControllerBase
    {
        private readonly IGenericRepository<TimesSheet> TimesSheetRepository;

        private readonly IMapper _mapper;

        public TimesSheetController(IGenericRepository<TimesSheet> TimesSheetRepository, IMapper mapper)
        {
            this.TimesSheetRepository = TimesSheetRepository;
            this._mapper = mapper;

        }

        [HttpGet("GetTimesSheet")]
        public async Task<IEnumerable<TimesSheet>> GeTimeSheet() =>
            await (new GetListGenericHandler<TimesSheet>(TimesSheetRepository)).Handle(new GetListGenericQuery<TimesSheet>(condition: null, includes: null), new CancellationToken());

        [HttpGet("GetTimesSheetById")]
        public async Task<TimesSheet> GetTacheById(Guid id) =>
           await (new GetGenericHandler<TimesSheet>(TimesSheetRepository)).Handle(new GetGenericQuery<TimesSheet>(condition: x => x.ID_TimesSheet.Equals(id), includes: null), new CancellationToken());

        [HttpGet("GetTimesSheetbyDate")]
        public async Task<IEnumerable<TimesSheet>> GeTimeSheetbyDate(string date, Guid personId) =>
           await (new GetListGenericHandler<TimesSheet>(TimesSheetRepository)).Handle(new GetListGenericQuery<TimesSheet>(condition: x => x.CreatedNow.Equals(date) && x.FK_Person.Equals(personId), includes: null), new CancellationToken());

        [HttpGet("GetTimesSheetByPerson")]
        public async Task<IEnumerable<TimesSheet>> GeTimeSheettByPerson(Guid id_Person) =>
           await (new GetListGenericHandler<TimesSheet>(TimesSheetRepository)).Handle(new GetListGenericQuery<TimesSheet>(condition: x => x.FK_Person.Equals(id_Person), includes: null), new CancellationToken());


        [HttpPost("AddTimesSheet")]
        public async Task<TimesSheet> AddTache([FromBody] TimesSheet TimesSheet)
        {

            return await (new AddGenericHandler<TimesSheet>(TimesSheetRepository)).Handle(new AddGenericCommand<TimesSheet>(TimesSheet), new CancellationToken());

        }

        [HttpPut("EditTimesSheet")]
        public async Task<String> EditTache([FromBody] TimesSheet TimesSheet)
        {
            return await (new PutGenericHandler<TimesSheet>(TimesSheetRepository)).Handle(new PutGenericCommand<TimesSheet>(TimesSheet), new CancellationToken());

        }


        [HttpDelete("DeleteTimesSheet")]
        public async Task<String> DeletePerson(Guid id) =>
            await (new DeleteGenericHandler<TimesSheet>(TimesSheetRepository)).Handle(new DeleteGenericCommand<TimesSheet>(id), new CancellationToken());



    }
}