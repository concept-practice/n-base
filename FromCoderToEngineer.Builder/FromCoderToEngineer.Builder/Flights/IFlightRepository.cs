namespace FromCoderToEngineer.Builder.Flights
{
    using Repository;

    public interface IFlightRepository :
        IAddEntity<Flight>,
        IGetAll<Flight>,
        IGetById<Flight>
    {
    }
}
