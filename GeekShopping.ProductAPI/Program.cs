
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace GeekShopping.ProductAPI {
    public class Program {
        public static void Main(string[] args) {

            var builder = WebApplication.CreateBuilder(args);

            string mySqlConnection = builder.Configuration.GetConnectionString("conexaoMySQL");

            builder.Services.AddDbContextPool<MySQLContext>(options =>
                options.UseMySql(
                    mySqlConnection,
                    new MySqlServerVersion(new Version())));

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}