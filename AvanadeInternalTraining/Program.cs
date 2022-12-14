var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// injetando a base de dados
builder.Services.AddDbContext<Data.Context.AvanadeInternalTrainingContext>();

builder.Services.AddScoped<Data.Interfaces.IClassRepository, Data.Repository.ClassRepository>();
builder.Services.AddScoped<Data.Interfaces.IStudentRepository, Data.Repository.StudentRepository>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyRuleCors",
        policy =>
        {
            policy.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();

        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyRuleCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
