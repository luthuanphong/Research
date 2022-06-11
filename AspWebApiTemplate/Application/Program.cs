
using Application.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.ConfigureKestrel(option =>
{
    option.ConfigureEndpointDefaults(endPointOpt =>
    {
        endPointOpt.UseHttps();
    });

    option.ConfigureHttpsDefaults(httpsOption =>
    {
        httpsOption.SslProtocols = System.Security.Authentication.SslProtocols.Tls13;
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.ConfigureAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
