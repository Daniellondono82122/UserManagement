using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UserManagement.Api.Mediator;
using UserManagement.Data;
using UserManagement.Domain.Interfaces.Data;
using UserManagement.Domain.Interfaces.Services;
using UserManagement.Services.Validators.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "UserManagement.Api",
        Version = "v1",
        Description = "Coink Test",
        Contact = new OpenApiContact
        {
            Name = "Daniel Londoño",
            Email = "daniel_londono82122@elpoli.edu.co"
        }
    });
});


builder.Services.AddDbContext<DatabaseContext>(options =>
                    options.UseSqlServer(builder.Configuration["Sql_Connection"],
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null);
                        sqlOptions.MigrationsAssembly("UserManagement.Api");
                    }));

builder.Services.AddMediatRConf();

builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<ICommonValidators, CommonValidators>();

builder.Services.AddValidatorsFromAssembly(typeof(CommonValidators).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
