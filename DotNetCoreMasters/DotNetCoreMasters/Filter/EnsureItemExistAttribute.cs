using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DotNetCoreMasters.Filter
{
    public class EnsureItemExistsFilter : IActionFilter
    {
        private readonly IItemService _service;

        public EnsureItemExistsFilter(IItemService service)
        {
            _service = service;
        }
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var itemId = (int)context.ActionArguments["itemId"];

            var item = _service.Get(itemId);

            if (item == null)
            {
                //context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new NotFoundResult();
            }
        }
    }

    public class EnsureItemExistAttribute : TypeFilterAttribute
    {
        public EnsureItemExistAttribute() : base(typeof(EnsureItemExistsFilter))
        {
        }
    }
}
