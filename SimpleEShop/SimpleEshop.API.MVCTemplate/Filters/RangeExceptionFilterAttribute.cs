using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SimpleEshop.API.MVCTemplate.Filters
{
    public class RangeExceptionFilterAttribute  : ExceptionFilterAttribute
    {
        public int Min { get; set; }
        public int Max { get; set; }

        //bu filtre, kullanıldığı action'da belirli bir exception fırlatıldığında çalışır
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                context.Result = new BadRequestObjectResult(new { Message = argumentOutOfRangeException.Message });
                context.ExceptionHandled = true;
           
            }
            
        }
    }
}
