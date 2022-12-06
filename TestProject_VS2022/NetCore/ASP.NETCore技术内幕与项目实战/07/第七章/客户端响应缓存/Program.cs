var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

//ע�⣬�����Ŀ������CORS����ȷ��app.UseCorsд��app.UseResponseCaching֮ǰ��
//app.UseCors();

//���÷���������Ӧ�����м��
//Ҫд�� app.MapControllers() ֮ǰ
//����������Ӧ������ںܶ����ƺͰ�ȫ���գ����������á���Ӧ�����м����
//app.UseResponseCaching(); 

app.MapControllers();

app.Run();
