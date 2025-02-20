using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleEshop.Application.Services;

namespace SimpleEshop.API.MVCTemplate.Filters
{
    public class IsExistsActionFilter(IProductService service) : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //1. action parametrelerinde id isimli bir parametre var mı?
            if (!context.ActionArguments.ContainsKey("id"))
            {
               context.Result = new BadRequestObjectResult(new { Message = "Id parametresi bulunamadı" });
            }


            //2. id parametresi varsa, bu parametre int mi?
            if (context.ActionArguments.TryGetValue("id", out object? value))
            {
                if (value is int id)
                {
                    if (!await service.IsExists(id))
                    {
                        context.Result = new NotFoundObjectResult(new { Message = "Ürün bulunamadı" });
                    }
                }

            }
        }
    }
}
