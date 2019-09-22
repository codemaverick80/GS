using System.Threading.Tasks;
using AutoMapper;
using GS.Core.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GS.Core.Api.Filters
{
    public class GenreResultFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value == null || resultFromAction.StatusCode <200 || resultFromAction.StatusCode >=300)
            {
                await next();
                return;
            }
            
            //Only work with AutoMapper version 4.0.1, does not work with newer version (7.0)
            //resultFromAction.Value =Mapper.Map(resultFromAction.Value);
            await next();
        }
    }

    public class GenreResultsFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;
            if (resultFromAction?.Value == null || resultFromAction.StatusCode <200 || resultFromAction.StatusCode >=300)
            {
                await next();
                return;
            }
            //resultFromAction.Value = Mapper.Map<GenresModel[]>(resultFromAction.Value);
            await next();
        }
    }
}