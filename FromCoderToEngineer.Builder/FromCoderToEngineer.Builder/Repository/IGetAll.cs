namespace FromCoderToEngineer.Builder.Repository
{
    using System.Collections.Generic;

    public interface IGetAll<T>
    {
        List<T> GetAll();
    }
}
