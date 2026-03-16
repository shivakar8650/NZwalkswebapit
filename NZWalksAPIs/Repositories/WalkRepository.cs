using Microsoft.EntityFrameworkCore;
using NZWalksAPIs.Data;
using NZWalksAPIs.Model.Domain;

namespace NZWalksAPIs.Repositories
{
    public class WalkRepository : IwalkRepository
    {
        private readonly NZWalkDBContext _dbContext;

        public WalkRepository( NZWalkDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Walks> CreateAsync(Walks walk)
        {
            try
            {
                var regionExists = await _dbContext.Regionspoperties
           .AnyAsync(x => x.Id == walk.RegionId);

                if (!regionExists)
                {
                    throw new Exception("Region does not exist");
                }
                await _dbContext.WalksProperties.AddAsync(walk);
                return walk;
            }
            catch(Exception ex)
            {
                throw;
            }
           
        }

        public async  Task<Walks?> DeleteAsync(Guid id)
        {
            var existingWalk = await _dbContext.WalksProperties.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            _dbContext.WalksProperties.Remove(existingWalk);
            _dbContext.SaveChanges();
            return existingWalk;

        }

        public async  Task<List<Walks>> GetAllAsync(string? filterOn=null , string? filterQuery = null,
            string? SortBy = null, bool isAsending = false, int pagenumber = 1, int pagesize = 1000)
        {
            var walks = _dbContext.WalksProperties.Include("Difficulty").Include("Region").AsQueryable();
            //filtering
            if(string.IsNullOrWhiteSpace(filterOn)== false && string.IsNullOrWhiteSpace(filterQuery)== false )
            {
                if(filterOn.Equals("Name",StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }
            //sorting
            if(string.IsNullOrWhiteSpace(SortBy) == false)
            {
                if (SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAsending ? walks.OrderBy( x=> x.Name): walks.OrderByDescending(x=> x.Name);
                }
                else if(SortBy.Equals("Length",StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAsending ? walks.OrderBy(x => x.LenghtInKm) : walks.OrderByDescending(x => x.LenghtInKm);
                }
            }
            //pagination
            var skipresult  = (pagenumber - 1) * pagesize;

            return await walks.Skip(skipresult).Take(pagesize).ToListAsync();
           //return  await _dbContext.WalksProperties.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walks?> GetbyId(Guid id)
        {
            var result = await _dbContext.WalksProperties
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<Walks?> UpdateAsync(Guid id, Walks walk)
        {
             var existingWalk =await _dbContext.WalksProperties.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LenghtInKm = walk.LenghtInKm;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;
           
            await _dbContext.SaveChangesAsync();
            return existingWalk;

        }
    }
}
