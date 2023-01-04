using Softeng_integration_be.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var corsPolicyName = "MyPolicy";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: corsPolicyName,
		policy => policy.WithOrigins("http://127.0.0.1:5501")
						.AllowAnyHeader()
						.AllowAnyMethod()
						.AllowCredentials()
	);
});

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();
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

app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
