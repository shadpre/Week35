

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    //c.SwaggerDoc("1.0", new Microsoft.OpenApi.Models.OpenApiInfo
    //{
    //    Version = "1.0",
    //    Title = "Week35 - Mrgl",
    //    Description = "School Project Week 35"
    //});
    c.CustomSchemaIds(type => type.FullName);
    //c.OperationFilter<GeneratePathParamsValidationFilter>();
});
//builder.Services.AddSingleton();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
