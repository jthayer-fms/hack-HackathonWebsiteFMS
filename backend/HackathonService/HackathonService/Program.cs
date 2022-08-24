using HackathonService.Dtos;
using HackathonService.Providers;
using HackathonService.Queries;
using HackathonService.RequestDtos;
using HackathonService.Services;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);
var AllowSpecificOrigins = "AllowSpecificOrigins";
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IEvents,Events>();
builder.Services.AddTransient<IPitchProvider, PitchProvider>();
builder.Services.AddTransient<IPitchService, PitchService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000");
                      });

});


var app = builder.Build();
app.UseCors(AllowSpecificOrigins);

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
        return Results.Created($"/pitch", pitch);
    }
});

app.MapGet("/pitches", [EnableCors("AllowSpecificOrigins")] async () => {

    List<Pitch> pitches = new List<Pitch>();
    var pitch1 = new Pitch(Guid.NewGuid(), Guid.NewGuid(), "Hackathon Website", new User("Michael Crawford"));
    var pitch2 = new Pitch(Guid.NewGuid(), Guid.NewGuid(), "Create a Service Request from the FMS:Workplace Floor plan", new User("David Kornegay"));
    var pitch3 = new Pitch(Guid.NewGuid(), Guid.NewGuid(), "FMS:Employee RS Database Export/Import by Region", new User("Kelly Schrag"));

    pitches.Add(pitch1);
    pitches.Add(pitch2);
    pitches.Add(pitch3);


    return Results.Created($"/pitches", pitches);
});

app.MapPut("/pitch/vote", async (IPitchService service, Guid pitchId, string userId) => {

    var result = await service.Vote(pitchId, new User(userId));

    if (result.success == true)
    {
        return Results.Created($"{userId} sign up pitch {pitchId} successfully", result);
    }
    else return Results.Json(result);

});

app.MapPut("/pitch/unvote", async (IPitchService service, Guid pitchId, string userId) => {

    var result = await service.Unvote(pitchId, new User(userId));

    if (result.success == true)
    {
        return Results.Created($"{userId} sign up pitch {pitchId} successfully", result);
    }
    else return Results.Json(result);
});

app.MapPut("/pitch/signUp", async (IPitchService service, Guid pitchId, string userId) => {

   var result =  await service.PitchSignUp(pitchId, new User(userId));

    if (result.success == true)
    {
        return Results.Created($"{userId} sign up pitch {pitchId} successfully", result);
    }
    else return Results.BadRequest(result);
});


app.Run();
