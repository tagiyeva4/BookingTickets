﻿using BookingTickets.Business.Dtos.ErrorDtos;
using BookingTickets.Business.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace BookingTickets.Presentation.Extensions;

    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            string errorName = "Upps something went wrong";
            string errorMessage = "An unexpected error occurred. Please contact the server.";

            if (exception is KeyNotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
            }
            else if (exception is UnauthorizedAccessException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                errorMessage = "You do not have permission to access this section.";
            }
            else if (exception is IBaseException e)
            {
                statusCode = (HttpStatusCode)e.StatusCode;
                errorMessage = exception.Message;
            }

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var errorDto = new ErrorDto
            {
                StatusCode = (int)statusCode,
                Message = errorMessage,
                Name = errorName
            };

            var result = JsonConvert.SerializeObject(errorDto);

            if (context.Request.Headers["Accept"].ToString().Contains("application/json"))
            {
                await context.Response.WriteAsync(result);
            }
            else
            {
                var errorPath = "/Home/Error";
                var query = $"?json={Uri.EscapeDataString(result)}";
                var fullPath = $"{errorPath}{query}";
                context.Response.Redirect(fullPath);
                await Task.CompletedTask;
            }
        }
    }

