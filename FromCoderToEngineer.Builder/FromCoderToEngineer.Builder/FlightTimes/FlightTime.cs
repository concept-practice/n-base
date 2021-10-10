namespace FromCoderToEngineer.Builder.FlightTimes
{
    using System;
    using Airplanes;

    public class FlightTime : Entity
    {
        public FlightTime(Guid id, DateTime departure, Airplane airplane)
            : base(id)
        {
            Departure = departure;
            Airplane = airplane;
        }

        protected FlightTime()
        {
        }

        public DateTime Departure { get; }

        public Airplane Airplane { get; }

        public override string ToString()
        {
            return $"Id: {Id} - Departure: {Departure} - Airplane: {Airplane}";
        }
    }
}
