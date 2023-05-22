using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PgMessageDb>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.MapGet("/pgmessage", (PgMessageDb db) => db.Messages.ToList());
app.MapPost("/pgmessage", (PgMessageDb db, Message message) =>
{
    db.Messages.Add(message);
    db.SaveChanges();
    return Results.Ok(message);
});
app.MapPut("/pgmessage/{id}", (PgMessageDb db, Message message, int id) =>
{
    var messageFounded = db.Messages.Find(id);
    if (messageFounded is null) return Results.NotFound();

    messageFounded.Nom = message.Nom;
    messageFounded.Description = message.Description;
    
    db.SaveChanges();
    return Results.Ok(messageFounded);
});

app.UseSwaggerUI();
app.Run();

public class PgMessageDb : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<Message> Messages { get; set; }

    public PgMessageDb(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("postgres"));
    }
}

[Table("message")]
public class Message
{
    [Key]
    [Column("id")]
    public int Id { get; set; } 
    
    [Column("nom")]
    public string Nom { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("date_cree")]
    public DateTime Date_cree { get; set; }
    
}
