namespace FromCoderToEngineer.Builder
{
    using System;
    using System.Linq;
    using Airplanes;
    using Flights;
    using FlightTimes;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FromCoderToEngineer.Builder;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddTransient<IAirplaneRepository, AirplaneRepository>();
            services.AddTransient<IFlightRepository, FlightRepository>();
            services.AddTransient<IFlightTimeRepository, FlightTimeDapperRepository>();
            services.AddTransient<SqlBuilder<FlightTime>, FlightTimeBuilder>();
            services.AddTransient<SqlBuilder<Airplane>, AirplaneBuilder>();
            services.AddTransient<SqlBuilder<Flight>, FlightBuilder>();
            services.AddScoped(_ => new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=FromCoderToEngineer.Builder;Trusted_Connection=True;MultipleActiveResultSets=true"));

            var provider = services.BuildServiceProvider();

            var repo = provider.GetService<IFlightTimeRepository>();

            //var airplaneRepo = provider.GetService<IAirplaneRepository>();

            //var allAirplanes = airplaneRepo.GetAll();

            //repo.AddEntity(new FlightTime(Guid.NewGuid(), DateTime.UtcNow, allAirplanes.First()));

            var flightTimes = repo.AllFlightTimesForAirplane(Guid.Parse("95953319-29B1-4A6B-A1A2-019CA91D3218"));

            flightTimes.ForEach(Console.WriteLine);

            Console.ReadLine();
        }
    }
}
