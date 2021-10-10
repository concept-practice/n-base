namespace FromCoderToEngineer.Builder.Flights
{
    using System;
    using System.Collections.Generic;

    public class FlightBuilder : SqlBuilder<Flight>
    {
        public FlightBuilder()
            : base("Flights", "Id", "FlightNumber")
        {
        }

        protected override Func<Flight, IReadOnlyList<string>> PropertyValues => flight => new List<string>
        {
            flight.Id.ToString(), flight.FlightNumber.ToString(),
        };
    }
}
