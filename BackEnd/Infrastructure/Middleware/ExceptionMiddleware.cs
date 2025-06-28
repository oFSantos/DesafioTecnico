public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // Continua executando a pipeline
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message); // Loga o erro
            await HandleExceptionAsync(context, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var response = new ErrorResponse
        {
            Status = 500,
            Message = _env.IsDevelopment()
                ? exception.Message
                : "Ocorreu um erro interno no servidor.",
            StackTrace = _env.IsDevelopment()
                ? exception.StackTrace
                : null
        };

        await context.Response.WriteAsJsonAsync(response);
    }

}
