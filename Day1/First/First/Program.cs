using First;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Use(async (context, next) => {

    await context.Response.WriteAsync(" My Middleware A1 \n");
    await next();
    await context.Response.WriteAsync(" My Middleware A2 \n");
});

app.Use(async (context, next) => {

    await context.Response.WriteAsync(" My Middleware B1 \n");
    await next();
    await context.Response.WriteAsync(" My Middleware B2 \n");
});

app.UseMiddleware<MiddlewareC>();
app.UseStaticFiles();
app.UseAddeaderMiddleware();
app.UseCheckHeaderMiddleware();

app.Run(async (context) => {

    await context.Response.WriteAsync(" APP RUN \n");
});


app.Run();

