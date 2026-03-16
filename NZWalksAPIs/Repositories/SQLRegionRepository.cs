using Microsoft.EntityFrameworkCore;
using NZWalksAPIs.Data;
using NZWalksAPIs.Model.Domain;

namespace NZWalksAPIs.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {  
        private readonly NZWalkDBContext _dbcontext;
        public SQLRegionRepository( NZWalkDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Regions> CreateAsync(Regions region)
        {
            await _dbcontext.Regionspoperties.AddAsync(region);
            await _dbcontext.SaveChangesAsync();
            return region;
        }

        public async Task<Regions?> DeleteAsync(Guid id)
        {
            var item = await _dbcontext.Regionspoperties.FirstOrDefaultAsync(x => x.Id == id);
                if(item == null)
                {
                    return null;
                }
          
              _dbcontext.Regionspoperties.Remove(item);
               await  _dbcontext.SaveChangesAsync();
               return item;
        }

        public async Task<List<Regions>> GetAllAsync()
        {

          return await _dbcontext.Regionspoperties.ToListAsync();
        }

        public async Task<Regions?> GetByIdAsyn(Guid id)
        {
           return await _dbcontext.Regionspoperties.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Regions?> UpdateAsync(Guid id, Regions region)
        {
           var existingregion = await _dbcontext.Regionspoperties.FirstOrDefaultAsync(x=> x.Id == id);
            if (existingregion == null)
            {
                return null;
            }

            existingregion.Code  = region.Code; 
            existingregion.Name =region.Name;
            existingregion.RegionImageUrl = region.RegionImageUrl;

            await _dbcontext.SaveChangesAsync();

            return existingregion;
        }
    }
}
