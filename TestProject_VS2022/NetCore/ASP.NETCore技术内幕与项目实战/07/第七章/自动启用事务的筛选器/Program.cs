using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ע�����ݿ����
builder.Services.AddDbContext<MyDbContext>(opt => {
    string connStr = builder.Configuration.GetConnectionString("Default");
    opt.UseSqlServer(connStr);
});

// ע���Զ��������������
builder.Services.Configure<MvcOptions>(opt => { 
    opt.Filters.Add<TransactionScopeFilter>();
});

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
