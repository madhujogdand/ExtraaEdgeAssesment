using ExtraaEdgeAssesment.Models;
using ExtraaEdgeAssesment.Services.Interfaces;
using ExtraaEdgeAssesnment.Repository.Interfaces;

namespace ExtraaEdgeAssesment.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository repo;
        public BrandService(IBrandRepository repo) 
        {
        this.repo = repo;
        }
        public int AddBrand(Brand brand)
        {
          return repo.AddBrand(brand);
        }

        public int DeleteBrand(int id)
        {
         return repo.DeleteBrand(id);
        }

        public Brand GetBrandById(int id)
        {
            return repo.GetBrandById(id);
        }

        public IEnumerable<Brand> GetBrands()
        {
         return repo.GetBrands();
        }

        public int UpdateBrand(Brand brand)
        {
          return repo.UpdateBrand(brand);
        }

        public void BulkInsertBrand(List<Brand> brands)
        {
           repo.BulkInsertBrand(brands);
        }

        public void BulkUpdateBrand(List<Brand> brands)
        {
           repo.BulkUpdateBrand(brands);
        }
    }
}
