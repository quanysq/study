using Zack.ASPNETCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ע��ֲ�ʽ�������
builder.Services.AddStackExchangeRedisCache(options => {
    // ���� Redis ���Ӵ�
    options.Configuration = "127.0.0.1:16379,allowadmin=true";

    // ���û���Keyǰ׺����������������ͻ����ΪRedis������������Ҳ��ʹ��
    options.InstanceName = "yzk_";
});

//ע���Զ���ķֲ�ʽ�����������ӿ�
builder.Services.AddScoped<IDistributedCacheHelper, DistributedCacheHelper>();

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
