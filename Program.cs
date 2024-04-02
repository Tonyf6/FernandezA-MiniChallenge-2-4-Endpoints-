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

//adding
app.MapGet("/add", (int num1, int num2) =>
{
    int sum = num1 + num2;
    return $"The sum of {num1} and {num2} is {sum}.";
});
//name and time
app.MapGet("/nameTime", (string name, string wakeupTime) =>{
    return $"So {name}, you woke up at {wakeupTime}?";
});
//greater or less than
app.MapGet("/greaterthanLessthan", (int num1, int num2) =>{
    string comparison1, comparison2;
    if (num1 > num2)
        comparison1 = "greater than";
    else if (num1 < num2)
        comparison1 = "less than";
    else
        comparison1 = "equal to";
    if (num2 > num1)
        comparison2 = "greater than";
    else if (num2 < num1)
        comparison2 = "less than";
    else
        comparison2 = "equal to";
    return $"{num1} is {comparison1} the {num2}.\n" +
           $"{num2} is {comparison2} the {num1}.";
});
app.Run();