namespace Upwork.Core.Data
{
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}