using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ������ע��������ע�����ʶ�����صķ��񣬲�����ص�ѡ���������
// ----1. ���ݿ�ע��
IServiceCollection services = builder.Services;
services.AddDbContext<IdDbContext>(opt =>
{
    string connStr = builder.Configuration.GetConnectionString("Default")!;
    opt.UseSqlServer(connStr);
});
// ----2.���ݱ�������ע��
// ----���ݱ����ṩ��һ���򵥡����ڷǶԳƼ��ܸĽ��ļ���API����ȷ��WebӦ���������ݵİ�ȫ�洢
// ----����Ҫ������Ա����������Կ��������ݵ�ǰӦ�õ����л��������ɸ�Ӧ�ö��е�һ��˽Կ
services.AddDataProtection();
// ----3. ��ӱ�ʶ��ܵ�һЩ��Ҫ�Ļ�������
services.AddIdentityCore<User>(options => { 
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
});
// ----4. ע�� UserManager��RoleManager�ȷ���
var idBuilder = new IdentityBuilder(typeof(User), typeof(Role), services);
idBuilder.AddEntityFrameworkStores<IdDbContext>()
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
