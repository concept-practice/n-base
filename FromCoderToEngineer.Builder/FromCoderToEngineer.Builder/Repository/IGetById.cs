namespace FromCoderToEngineer.Builder.Repository
{
    using System;

    public interface IGetById<out T>
    {
        T GetById(Guid id);
    }
}
