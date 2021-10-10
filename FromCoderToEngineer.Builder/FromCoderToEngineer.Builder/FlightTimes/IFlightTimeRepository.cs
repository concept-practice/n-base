namespace FromCoderToEngineer.Builder.FlightTimes
{
    using System;
    using System.Collections.Generic;
    using Repository;

    public interface IFlightTimeRepository :
        IAddEntity<FlightTime>,
        IGetAll<FlightTime>
    {
        List<FlightTime> AllFlightTimesForAirplane(Guid airplaneId);
    }
}
