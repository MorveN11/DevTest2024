using PollDb.Application.Repositories;
using PollDb.Infrastructure.Repositories.Lists;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

builder.Services.AddSingleton<IOptionRepository, OptionListRepository>();
builder.Services.AddSingleton<IPollRepository, PollListRepository>();
builder.Services.AddSingleton<IVoteRepository, VoteListRepository>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseCors();

app.Run();
