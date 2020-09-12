namespace Upwork.Core.Data
{
    using System;

    public interface IRepository<T> : IDisposable
        where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}