using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OSBookReviewWepApi.Services;
using OSDataAccessLibrary;
using OSDataAccessLibrary.DataServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add rest controllors withou view
builder.Services.AddControllers();
// add dependency injection interface references
builder.Services.AddTransient<IDataAccess, DataAccess>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<ILoginData, LoginData>();
builder.Services.AddTransient<IDataClass, DataClass>();
// add authenticaion , using jwt bearing token authentincation for api calls
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {

            ValidateAudience = false,
            //ValidAudience = "the audience you want to validate",
            ValidateIssuer = false,
            //ValidIssuer = "the iusser you want to validate",

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OSPProject2022MTUBrianRDanielC")),

            ValidateLifetime = true, //validate the expiration and not before values in the token

            ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
        };
    });


builder.Services.AddAuthorization(auth =>
    {
        auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser().Build());
    });

// if using swagger as api end point on developement would have this part uncommentted
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "BookReviewApi",
//        Version = "v1",
//        Description = "BookReview Api ",
//        TermsOfService = new Uri("https://example.com/terms"),
//        Contact = new OpenApiContact
//        {
//            Name = "BR",
//            Email = string.Empty,
//            Url = new Uri("https://twitter.com/reville2004"),
//        },
//        License = new OpenApiLicense
//        {
//            Name = "Use under LICX",
//            Url = new Uri("https://example.com/license"),
//        }
//    });
//    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    // uncomment if using swagger as landing page for developement and wishing to view api calls
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RoomCareApi v1"));
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
