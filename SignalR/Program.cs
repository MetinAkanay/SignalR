using SignalR.SignalR;

namespace SignalR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSignalR();
            builder.Services.AddCors();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Cors", builder =>
                {
                    builder.WithOrigins("http://localhost/1010","http://localhost/2020").
                    AllowAnyHeader().
                    AllowAnyMethod().
                    AllowAnyMethod();

                });
            });

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


            

            // Signal R' ýn ayný web socketteki gibi bir hizmet vereceði adres olacaktýr. bu adresi aspnet core uygulamasýndaki gibi bir endpoint eklememiz gerekiyor
            app.UseEndpoints(endpoints =>
            {
                // Dýþarýdan gelen paketler http://localhost:5050/wissen
                endpoints.MapHub<MessageHub>("/wissen");
            });

            app.UseCors("cors");

            app.Run();
        }
    }
}
