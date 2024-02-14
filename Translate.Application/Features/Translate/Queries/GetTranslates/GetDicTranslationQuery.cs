using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Translate.Application.Features.Translate.Queries.GetTranslateTables;

namespace Translate.Application.Features.Translate.Queries.GetTranslates
{
    public record GetDicTranslationQuery: IRequest<List<DicTranslationDto>>
    {
        public string TableName { get; set; }
        public int TableTypeCode { get; set; }
        public int StatusCode { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public GetDicTranslationQuery(JsonElement data)
        {
            string tableName = data.GetProperty("tableName").ToString();
            int tableTypeCode = int.Parse(data.GetProperty("tableTypeCode").ToString());
            int statusCode = int.Parse(data.GetProperty("statusCode").ToString());
            int pageIndex = int.Parse(data.GetProperty("pageIndex").ToString()) - 1;
            int pageSize = int.Parse(data.GetProperty("pageSize").ToString());
        }

           
        

    }
}
