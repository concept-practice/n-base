namespace FromCoderToEngineer.Builder.Airplanes
{
    using System;
    using System.Collections.Generic;

    public class AirplaneBuilder : SqlBuilder<Airplane>
    {
        public AirplaneBuilder()
            : base("Airplanes", "Id", "Manufacturer", "Model")
        {
        }

        protected override Func<Airplane, IReadOnlyList<string>> PropertyValues => airplane => new List<string>
        {
            airplane.Id.ToString(), airplane.Manufacturer, airplane.Model,
        };
    }
}
