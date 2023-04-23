using SoapCore;
using SoapServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

((IApplicationBuilder)app).UseSoapEndpoint<IProductService>("/Service.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);

SoapServer.Data.ProductSet.InflateData();

app.Run();
