var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Postgresql & Kafka
// Afficher messages
// Créer message
// Mettre à jour message

app.UseSwagger();

app.MapGet("/", () => "Hello World!")
    .WithName("Hello");
app.UseSwaggerUI();
app.Run();
