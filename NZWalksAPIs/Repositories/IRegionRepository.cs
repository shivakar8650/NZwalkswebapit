using NZWalksAPIs.Model.Domain;

namespace NZWalksAPIs.Repositories
{
    public interface IRegionRepository
    {
       Task<List<Regions>> GetAllAsync();

        Task<Regions?> GetByIdAsyn(Guid id);

         Task<Regions> CreateAsync(Regions region);
         Task<Regions?> UpdateAsync(Guid id, Regions region);
         Task<Regions?> DeleteAsync(Guid id);
    }
}
