using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ע�����ݿ������ķ���
// ʹ��AddDbContext������ͨ������ע��ķ�ʽ��MyDbContext����ָ���������ַ����������ݿ⡣
// ����AddDbContext�����Ƿ��͵ģ���˿���Ϊͬһ����Ŀ�еĶ����ͬ���������趨���Ӳ�ͬ�����ݿ⡣
builder.Services.AddDbContext<MyDbContext>(opt =>
{
    string connStr = builder.Configuration.GetConnectionString("Default")!;
    opt.UseSqlServer(connStr);
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
