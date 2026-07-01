using NZWalksAPIs.Model.Domain;
using System.Net;

namespace NZWalksAPIs.Repositories
{
    public interface IImageRepository
    {

       Task<Image> Upload ( Image image);
    }
}
