namespace FromCoderToEngineer.Builder.Airplanes
{
    using System;

    public class Airplane : Entity
    {
        public Airplane(Guid id, string manufacturer, string model)
            : base(id)
        {
            Manufacturer = manufacturer;
            Model = model;
        }

        public string Manufacturer { get; }

        public string Model { get; }

        public override string ToString()
        {
            return $"Id: {Id} - Manufacturer: {Manufacturer} - Model: {Model}\n";
        }
    }
}
