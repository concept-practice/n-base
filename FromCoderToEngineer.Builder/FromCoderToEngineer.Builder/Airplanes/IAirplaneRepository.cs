namespace FromCoderToEngineer.Builder.Airplanes
{
    using Repository;

    public interface IAirplaneRepository :
        IGetAll<Airplane>,
        IGetById<Airplane>,
        IAddEntity<Airplane>,
        IDeleteById,
        IUpdateEntity<Airplane>
    {
    }
}
