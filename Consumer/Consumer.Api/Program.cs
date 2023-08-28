using Consumer.Api;
using Steeltoe.Common;
using Steeltoe.Extensions.Configuration.Kubernetes;

var builder = WebApplication.CreateBuilder(args);

if (Platform.IsKubernetes)
{
    builder.AddKubernetesConfiguration();   
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<EncodingApiClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["EncodingApi:Uri"]!);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Configuration is IConfigurationRoot configurationRoot)
{
    Console.WriteLine(configurationRoot.GetDebugView());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
