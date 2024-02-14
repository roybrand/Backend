using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using System.Drawing.Printing;
using MediatR;
using Translate.Application.Features.Translate.Queries.GetTranslates;
using Translate.Application.Features.Translate.Queries.GetTranslateTables;
using Translate.Application.Features.Translate.Queries.GetTableTranslate;
using Translate.Application.Features.Translate.Queries.GetTranslationTables;

namespace Backend.Controllers
{
    [ApiController]

    public class DictionaryTranslateController : ControllerBase
    {

        private readonly IMediator _mediator;


        public DictionaryTranslateController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        public async Task<List<DicTranslationDto>> GetTranslates([FromBody] JsonElement data)
        {
            var dicTranslations = await _mediator.Send(new GetDicTranslationQuery(data));

            return dicTranslations;
        }

        public async Task<List<TablesNamesDto>> GetTranslationTables()
        {
            var translationTables = await _mediator.Send(new GetTranslationTablesQuery());

            return translationTables;
        }
    }
}
