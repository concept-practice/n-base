namespace FromCoderToEngineer.Builder.FlightTimes
{
    using System;
    using System.Collections.Generic;

    public class FlightTimeBuilder : SqlBuilder<FlightTime>
    {
        public FlightTimeBuilder()
            : base("FlightTimes", "Id", "Departure", "AirplaneId")
        {
        }

        protected override Func<FlightTime, IReadOnlyList<string>> PropertyValues { get; } = flightTime => new List<string>
        {
            flightTime.Id.ToString(), flightTime.Departure.ToString(), flightTime.Airplane.Id.ToString(),
        };
    }
}
