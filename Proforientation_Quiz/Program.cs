using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proforientation_Quiz.Data;
using Proforientation_Quiz.Data.CareerTest.Data;
using Proforientation_Quiz.Data.Repositorys;
using Proforientation_Quiz.Data.Repositorys.Interfaces;
using Proforientation_Quiz.Models;
using Proforientation_Quiz.Services;
using Proforientation_Quiz.Services.Interfaces;

namespace Proforientation_Quiz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<User, IdentityRole>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IUserAnswerRepository, UserAnswersRepository>();
            builder.Services.AddScoped<IProfessionRepository, ProfessionRepository>();
            builder.Services.AddScoped<IQuizResultRepository, QuizResultRepository>();
            builder.Services.AddScoped<IQuizAttemptRepository, QuizAttemptRepository>();
            builder.Services.AddScoped<IQuizService, QuizService>();
            builder.Services.AddScoped<IProfessionService, ProfessionService>();
            

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                 SeedData.InitializeAsync(services);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
