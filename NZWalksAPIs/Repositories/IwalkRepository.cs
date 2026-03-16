using Microsoft.AspNetCore.Mvc;
using NZWalksAPIs.Model.Domain;

namespace NZWalksAPIs.Repositories
{
    public interface IwalkRepository
    {

        Task<Walks> CreateAsync(Walks walk);

        Task<List<Walks>> GetAllAsync(string? filteron=null, string? filterQuery =null, string? SortBy=null ,bool isAsending =false
            ,int pagenumber=1, int pagesize=1000);

        Task<Walks?> GetbyId(Guid id);

         Task<Walks?> UpdateAsync(Guid id, Walks walk);

         Task<Walks?> DeleteAsync(Guid id);
    }
}
