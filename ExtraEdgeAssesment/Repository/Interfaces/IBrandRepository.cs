using ExtraaEdgeAssesment.DTO;
using ExtraaEdgeAssesment.Models;

namespace ExtraaEdgeAssesnment.Repository.Interfaces
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetBrands();
        Brand GetBrandById(int id);
        int AddBrand(Brand brand);  
        int UpdateBrand(Brand brand);
        int DeleteBrand(int id);
        public void BulkInsertBrand(List<Brand> brands);
        public void BulkUpdateBrand(List<Brand> brands);
    }
}
