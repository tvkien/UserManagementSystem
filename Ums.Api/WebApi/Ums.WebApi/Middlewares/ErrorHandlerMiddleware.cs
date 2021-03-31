using Ums.Application.Exceptions;
using Ums.Application.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ums.WebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

                if (context.Response.StatusCode != (int)HttpStatusCode.OK)
                {
                    await HandleStatusNotSuccessAsync(context);
                }
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(exception, context);
            }
        }

        private async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var responseModel = new Response<string>()
            {
                Succeeded = false,
                Message = exception.Message
            };

            switch (exception)
            {
                case ApiException e:
                    _logger.LogError(e.Message);
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case ValidationException e:
                    _logger.LogError(e.Message);
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Errors = e.Errors;
                    break;
                case KeyNotFoundException e:
                    _logger.LogError(e.Message);
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    _logger.LogError(exception, exception.Message);
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            var result = JsonSerializer.Serialize(responseModel);

            await response.WriteAsync(result);
        }

        private async Task HandleStatusNotSuccessAsync(HttpContext context)
        {
            var responseModel = new Response<string>()
            {
                Succeeded = false,
            };

            var statusCode = context.Response.StatusCode;

            switch (statusCode)
            {
                case (int)HttpStatusCode.NoContent:
                    responseModel.Message = "The specified URI does not contain any content.";
                    break;
                case (int)HttpStatusCode.Forbidden:
                    responseModel.Message = "Forbidden : You don't have permission to perform this request.";
                    break;
            }

            var result = JsonSerializer.Serialize(responseModel);
            await context.Response.WriteAsync(result);
        }
    }
}