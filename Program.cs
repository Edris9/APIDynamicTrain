using FluentValidation;
using FluentValidation.AspNetCore;
using MinForstaApi.Validators;


namespace MinForstaApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddRazorPages();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();  // Hittar alla validators
            builder.Services.AddHttpClient<Services.FakeStoreService>();  // Lägger till vår service som kan prata med externa API:et

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseStaticFiles();  // Gör att vi kan servera filer från wwwroot
            app.MapControllers();
            app.MapRazorPages();  // Gör att Razor Pages fungerar
            app.Run();
        }
    }
}