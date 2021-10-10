namespace FromCoderToEngineer.Builder.Flights
{
    using System;

    public class Flight : Entity
    {
        public Flight(Guid id, int flightNumber)
            : base(id)
        {
            FlightNumber = flightNumber;
        }

        public int FlightNumber { get; }

        public override string ToString()
        {
            return $"Id: {Id} - FlightNumber: {FlightNumber}\n";
        }
    }
}
