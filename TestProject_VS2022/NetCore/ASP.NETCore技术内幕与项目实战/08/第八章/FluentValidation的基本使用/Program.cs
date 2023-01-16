using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ע�� FluentValidation ����
//builder.Services.AddFluentValidation(fv =>
//{
//    // �ɵ�д�����Ѿ�������
//    // ��Assembly.GetExecutingAssembly��ȡ�����Ŀ�ĳ���
//    // RegisterValidatorsFromAssembly�������ڰ�ָ������������ʵ����IValidator�ӿڵ�����У����ע�ᵽ����ע��������
//    // �������У����λ�ڶ�������У����Ե���RegisterValidatorsFromAssemblies��ָ����Щ���򼯽���ע��
//    Assembly assembly = Assembly.GetExecutingAssembly();
//    fv.RegisterValidatorsFromAssembly(assembly);
//});
Assembly assembly = Assembly.GetExecutingAssembly();
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssembly(assembly);
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
