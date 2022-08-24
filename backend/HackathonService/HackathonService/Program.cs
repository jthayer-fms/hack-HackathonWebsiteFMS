using HackathonService.Dtos;
using HackathonService.Queries;
using HackathonService.RequestDtos;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IEvents,Events>();
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

app.MapPost("/event", async (HackathonEvent events) => {

    return Results.Created($"/events/{events.id}", events);
});

app.MapPost("/pitch", async (IEvents eventProvider, CreatePitchRequest pitch, Guid eventId) => {

    var exisitingEvent = await eventProvider.GetById(eventId);
    var pitchId = Guid.NewGuid();

    if (DateTime.UtcNow > exisitingEvent.endTime)
    {
        return Results.BadRequest("the event is completed");
    }
    else
    {   
        return Results.Created($"/pitch/{pitchId}", pitch);
    }
});

app.MapGet("/pitches", async () => {

    List<Pitch> pitches = new List<Pitch>();
    var pitch1 = new Pitch(Guid.NewGuid(), Guid.NewGuid(), "Hackathon Website", new User("Michael Crawford"));
    var pitch2 = new Pitch(Guid.NewGuid(), Guid.NewGuid(), "Create a Service Request from the FMS:Workplace Floor plan", new User("David Kornegay"));
    var pitch3 = new Pitch(Guid.NewGuid(), Guid.NewGuid(), "FMS:Employee RS Database Export/Import by Region", new User("Kelly Schrag"));

    pitches.Add(pitch1);
    pitches.Add(pitch2);
    pitches.Add(pitch3);


    return Results.Created($"/pitches", pitches);
});

app.MapPut("/pitch/vote", async (string pitchId, string userId) => {

    return Results.Created($"/pitch/{pitchId}", pitchId);
});

app.MapPut("/pitch/unVote", async (Pitch pitchId, string userId) => {

    return Results.Created($"/pitch/{pitchId}", userId);
});

app.MapPut("/pitch/signUp", async (Pitch pitchId, string userId) => {

    return Results.Created($"/pitch/{pitchId}", userId);
});


app.Run();
