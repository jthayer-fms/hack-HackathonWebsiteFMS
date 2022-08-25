using HackathonService.Dtos;
using HackathonService.Persistency;
using HackathonService.Providers;
using HackathonService.Queries;
using HackathonService.RequestDtos;
using HackathonService.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var AllowSpecificOrigins = "AllowSpecificOrigins";
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IEvents, Events>();
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



builder.Services.AddDbContext<HackContext>(opt => opt.UseInMemoryDatabase("HackDB"), ServiceLifetime.Scoped);

var app = builder.Build();
app.UseCors(AllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/event", async (HackContext context, HackathonEvent events) =>
{

    try
    {
        context.Events.Add(events);
        context.SaveChanges();
        return Results.Created($"/events/{events.id}", events);
    }
    catch (Exception ex)
    {
        return Results.Created($"/events/{ex.Message}", events);

    }

});

app.MapGet("/events", [EnableCors("AllowSpecificOrigins")] async (HackContext context) =>
{
    try
    {
        var events = await context.Events.ToListAsync();
        return Results.Ok(events);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.MapPost("/pitch", async (IEvents eventProvider, CreatePitchRequest pitchRequest, Guid eventId, HackContext context) =>
{

    var exisitingEvent = await eventProvider.GetById(eventId);

    var creator = await context.Users.FindAsync(pitchRequest.Creator.id);
    if (creator == null)
    {
        creator = context.Users.FirstOrDefault(u => u.email == pitchRequest.Creator.email);
    }
    if (creator == null)
    {
        creator = context.Users.FirstOrDefault(u => u.name == pitchRequest.Creator.name);
    }
    if (creator == null)
    {
        context.Users.Add(pitchRequest.Creator);
        context.SaveChanges();
    }

    var newPitch = new Pitch(eventId, pitchRequest);

    context.Pitches.Add(newPitch);
    context.SaveChanges();

    if (DateTime.UtcNow > exisitingEvent.endTime)
    {
        return Results.BadRequest("the event is completed");
    }
    else
    {
        return Results.Created($"/pitch", newPitch);
    }
});

app.MapGet("/pitches", [EnableCors("AllowSpecificOrigins")] async (HackContext context) =>
{
    try
    {
        var pitches = await context.Pitches.Include("creator").Include("pitchMembers").ToListAsync();
        return Results.Ok(pitches);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.MapPut("/pitch/vote", async (HackContext context, IPitchService service, Guid pitchId, Guid userId) =>
{
    var user = await context.Users.FindAsync(userId);

    if (user == null)
    {
        return Results.Problem(@$"{userId} does not corrsepond to a user in the database");
    }

    var result = await service.Vote(pitchId, user);

    if (result.success == true)
    {
        return Results.Created($"{userId} sign up pitch {pitchId} successfully", result);
    }
    else return Results.Json(result);

});

app.MapPut("/pitch/unvote", async (HackContext context, IPitchService service, Guid pitchId, Guid userId) =>
{

    var user = await context.Users.FindAsync(userId);

    if (user == null)
    {
        return Results.Problem(@$"{userId} does not corrsepond to a user in the database");
    }

    var result = await service.Unvote(pitchId, user);

    if (result.success == true)
    {
        return Results.Created($"{userId} sign up pitch {pitchId} successfully", result);
    }
    else return Results.Json(result);
});

app.MapPut("/pitch/signUp", async (HackContext context, IPitchService service, Guid pitchId, Guid userId) =>
{
    var user = await context.Users.FindAsync(userId);

    if (user == null)
    {
        return Results.Problem(@$"{userId} does not corrsepond to a user in the database");
    }
    var result = await service.PitchSignUp(pitchId, user);

    if (result.success == true)
    {
        return Results.Created($"{userId} sign up pitch {pitchId} successfully", result);
    }
    else return Results.BadRequest(result);
});


app.Run();
