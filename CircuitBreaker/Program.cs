using Polly;

var builder = WebApplication.CreateBuilder(args);

//retry from poly (apart from circuit breaker)
//var retryPolicy = Policy.HandleResult<HttpResponseMssage>(r=> 1r.IsSuccessStatusCode)
//    .OrTransientHttpError()
//    .WaitAndRetryAsync(3, retryDuration => TimeSpan.FromSeconds(120));
//builder.Services.AddHttpClient("proucctservice", c =>
//{
//    c.BaseAddress = new Uri("http://localhost:5050/");
//}).AddPolicyHandler(retryPolicy);


// Add services to the container.
//It will try to call the mentioned uri, as its going to break. So the next upcoming request will be blocked for 30 seconds
builder.Services.AddHttpClient("errorApiClient", c =>
{
    c.BaseAddress = new Uri("http://localhost:5050/");
}).AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(2, TimeSpan.FromSeconds(30)));


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
