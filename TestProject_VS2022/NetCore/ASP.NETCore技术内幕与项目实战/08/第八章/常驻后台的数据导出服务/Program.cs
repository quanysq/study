using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IServiceCollection services = builder.Services;

// ע���йܷ���
services.AddHostedService<ExplortStatisticBgService>();

// ע�����ݿ�������
services.AddDbContext<TestDbContext>(options => {
    string connStr = builder.Configuration.GetConnectionString("Default")!;
    options.UseSqlServer(connStr);
});

// ���ݱ�������ע��
// ----���ݱ����ṩ��һ���򵥡����ڷǶԳƼ��ܸĽ��ļ���API����ȷ��WebӦ���������ݵİ�ȫ�洢
// ----����Ҫ������Ա����������Կ��������ݵ�ǰӦ�õ����л��������ɸ�Ӧ�ö��е�һ��˽Կ
services.AddDataProtection();

// ע�� Identity ��ܵ�һЩ��Ҫ�Ļ�������
// ���û������������ע�� UserManager �ȷ���������⣬�����޷�����
services.AddIdentityCore<User>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
});

// ע�� UserManager��RoleManager ��Identity ��ܷ���
var idBuilder = new IdentityBuilder(typeof(User), typeof(Role), services);
idBuilder.AddEntityFrameworkStores<TestDbContext>()
    .AddDefaultTokenProviders()
    .AddRoleManager<RoleManager<Role>>()
    .AddUserManager<UserManager<User>>();

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
