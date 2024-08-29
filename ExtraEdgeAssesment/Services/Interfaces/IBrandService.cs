using ExtraaEdgeAssesment.DTO;
using ExtraaEdgeAssesment.Models;

namespace ExtraaEdgeAssesment.Services.Interfaces
{
    public interface IBrandService
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
