using ApplicationFormTask.Configurations;
using ApplicationFormTask.Mapping;
using ApplicationFormTask.Repositories;
using ApplicationFormTask.Services;
using AutoMapper;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Bind the CosmosDbConfig section to the CosmosDbConfig class
var cosmosDbConfig = new CosmosDbConfig();
builder.Configuration.GetSection("CosmosDb").Bind(cosmosDbConfig);

// Register CosmosClient as a singleton
builder.Services.AddSingleton(s => new CosmosClient(cosmosDbConfig.Account, cosmosDbConfig.Key));

// Register repositories and services
builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
builder.Services.AddScoped<IProgramService, ProgramService>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionTypeRepository, QuestionTypeRepository>();
builder.Services.AddScoped<IQuestionTypeService, QuestionTypeService>();


// Register configuration class
builder.Services.Configure<CosmosDbConfig>(builder.Configuration.GetSection("CosmosDb"));


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
