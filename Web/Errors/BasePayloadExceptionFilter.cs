using Api.Errors.Models;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Errors
{
    internal abstract class BasePayloadExceptionFilterAttribute : BaseExceptionFilterAttribute
    {
        protected BasePayloadExceptionFilterAttribute(ILogger logger) : base(logger) { }

        internal virtual void SetResponse(ExceptionContext context, Func<ErrorModel, ObjectResult> resultCreator)
        {
            var exception = context.Exception as PayloadException;

            context.Result = resultCreator(new ErrorModel(exception!.ErrorCode, exception.Message));

            context.ExceptionHandled = true;

            Log(context);
        }
    }
}