using HackathonService.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/event", async (HackathonEvents events) => {

    return Results.Created($"/events/{events.id}", events);
});

app.MapPost("/pitche", async (Pitches pitche) => {

    return Results.Created($"/pitche/{pitche.id}", pitche);
});

app.MapPut("/pitche/vote", async (string pitcheId, string userId) => {

    return Results.Created($"/pitches/{pitcheId}", pitcheId);
});

app.MapPut("/pitche/unVote", async (Pitches pitcheId, string userId) => {

    return Results.Created($"/pitches/{pitcheId}", userId);
});

app.MapPut("/pitche/signUp", async (Pitches pitcheId, string userId) => {

    return Results.Created($"/pitches/{pitcheId}", userId);
});


app.Run();
