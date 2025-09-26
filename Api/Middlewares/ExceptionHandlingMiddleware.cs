using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, "Ocorreu um erro inesperado");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        HttpStatusCode status;
        string message;

        switch (ex)
        {
            case DbUpdateConcurrencyException concurrencyEx:
                status = HttpStatusCode.Conflict;
                message = "O recurso foi alterado por outro usuário. Tente novamente.";
                break;
            case DbUpdateException dbEx:
                status = HttpStatusCode.BadRequest;
                message = "Erro ao salvar os dados no banco de dados.";
                break;
            case DivideByZeroException divideEx:
                status = HttpStatusCode.BadRequest;
                message = "Erro de cálculo: divisão por zero.";
                break;
            default:
                status = HttpStatusCode.InternalServerError;
                message = "Ocorreu um erro inesperado no servidor.";
                break;
        }

        context.Response.StatusCode = (int)status;

        var response = new
        {
            Success = false,
            Message = message,
            Detail = ex.Message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}