var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApiVersioning();

builder.Services.AddVersionedApiExplorer(options =>
                                         {
                                             options.GroupNameFormat = "'v'VVV";
                                             options.SubstituteApiVersionInUrl = true;
                                         });

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
