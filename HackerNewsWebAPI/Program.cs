using hackerNewsBusiness.Interface;
using hackerNewsBusiness.Services;



var builder = WebApplication.CreateBuilder(args);
ConfigurationManager _configuration = builder.Configuration;

// Add services to the container
// builder.Services.AddRazorPages();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IhackerService, hackerService>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//app.UseSwaggerUI(c =>
//    {
//        //c.DefaultModelsExpandDepth(-1); // Disable swagger schemas at bottom
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TE Admin API v1");
//    });

//}


app.UseHttpsRedirection();

//var options = new DefaultFilesOptions();
//options.DefaultFileNames.Clear();
//options.DefaultFileNames.Add("index.html");
//app.UseDefaultFiles(options);
//app.UseFileServer(enableDirectoryBrowsing: true);

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
