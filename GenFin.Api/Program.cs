var builder = WebApplication.CreateBuilder( new WebApplicationOptions()
{
    ApplicationName = "{ALTERAR}", // Alterar ao criar
    ContentRootPath = AppContext.BaseDirectory,
    Args = args
} );

builder.Host.UseWindowsService( opcao => opcao.ServiceName = builder.Environment.EnvironmentName + "Service" );
builder.Configuration.InjectConfiguration();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors( opcao => opcao.AddPolicy( "HabilitarOrigem", politica =>
{
    politica.WithOrigins( @"https://localhost:7143" )
            .AllowAnyHeader()
            .AllowAnyMethod();
} ) );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI( item =>
    {
        item.SwaggerEndpoint( "/swagger/v1/swagger.json", app.Environment.ApplicationName );
        item.InjectStylesheet( "/swagger/custom.css" );
    } );

    app.UseHsts();
}

app.MapHealthChecks( "/HealthCheck" );
app.UseCors( "HabilitarOrigem" );
app.UseDeveloperExceptionPage( new DeveloperExceptionPageOptions() );
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();