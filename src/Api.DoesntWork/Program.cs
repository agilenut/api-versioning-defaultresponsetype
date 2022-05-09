var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApiVersioning()
       .AddMvc()
       .AddApiExplorer(options =>
                       {
                           options.GroupNameFormat = "'v'VVV";
                           options.SubstituteApiVersionInUrl = true;
                       });

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
