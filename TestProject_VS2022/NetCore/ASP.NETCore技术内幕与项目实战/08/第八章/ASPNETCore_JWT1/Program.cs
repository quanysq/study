using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// ���� Swagger ֧�� Authorization
builder.Services.AddSwaggerGen(c => {
    var scheme = new OpenApiSecurityScheme()
    {
        Description = "Authorization header. \r\nExample: 'Bearer 12345abcdef'",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Authorization"
        },
        Scheme = "oauth2",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    };
    c.AddSecurityDefinition("Authorization", scheme);
    var requirement = new OpenApiSecurityRequirement();
    requirement[scheme] = new List<string>();
    c.AddSecurityRequirement(requirement);
});

var services = builder.Services;
// ע�����ݿ����
services.AddDbContext<IdDbContext>(opt => {
    string connStr = builder.Configuration.GetConnectionString("Default")!;
    opt.UseSqlServer(connStr);
});

// ע�����ݱ�������
services.AddDataProtection();

// ע�� IdentityCore ����
services.AddIdentityCore<User>(options => { 
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
});

// ע��UserManager��RoleManager�ȷ���
var idBuilder = new IdentityBuilder(typeof(User), typeof(Role), services);
idBuilder.AddEntityFrameworkStores<IdDbContext>()
    .AddDefaultTokenProviders()
    .AddRoleManager<RoleManager<Role>>()
    .AddUserManager<UserManager<User>>();

// ע�� JWT ����
services.Configure<JWTOptions>(builder.Configuration.GetSection("JWT"));

// ע�� JwtBearer ����
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x => { 
        var jwtOpt = builder.Configuration.GetSection("JWT").Get<JWTOptions>();
        byte[] keyBytes = Encoding.UTF8.GetBytes(jwtOpt.SigningKey);
        var secKey = new SymmetricSecurityKey(keyBytes);
        x.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = secKey
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ʹ�� Authentication �м�������� UseAuthorization ֮ǰ
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
