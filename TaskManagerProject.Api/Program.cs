using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using TaskManagerProject.Data;
using TaskManagerProject.Data.Repositories;
using TaskManagerProject.Entities;
using TaskManagerProject.Interfaces;
using TaskManagerProject.Services;

var builder = WebApplication.CreateBuilder(args);

BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "mongodb://localhost:27017/";
string databaseName = "TaskManager";

builder.Services.AddSingleton(new MongoContext(connectionString, databaseName));

builder.Services.AddScoped<IRepository<Activity>>(sp =>
    new Repository<Activity>(sp.GetRequiredService<MongoContext>(), "Activities"));

builder.Services.AddScoped<IActivityService, ActivityService>();

var app = builder.Build();

// Configura o Swagger para podermos testar no navegador (apenas em desenvolvimento)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona chamadas HTTP para HTTPS por segurança
app.UseHttpsRedirection();

//Importante: Diz ao app para usar os Controllers que eu criei
app.MapControllers();

app.Run();
