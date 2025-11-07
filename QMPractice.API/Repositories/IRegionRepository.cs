using QMPractice.API.Modesls.Domain;

namespace QMPractice.API.Repositories
{
    public interface IRegionRepository
    {
      public Task<List<Region>> GetAllAsync();
    }
}
