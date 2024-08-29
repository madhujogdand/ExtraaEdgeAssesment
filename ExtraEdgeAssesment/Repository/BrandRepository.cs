using ExtraaEdgeAssesnment.Repository.Interfaces;
using ExtraaEdgeAssesment.Models;
using ExtraaEdgeAssesment.Data;
using ExtraaEdgeAssesment.DTO;

namespace ExtraaEdgeAssesment.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext db)
        {
            this._context = db;
        }
        public int AddBrand(Brand brand)
        {
            int result = 0;
            _context.Brands.Add(brand);
            result=_context.SaveChanges();
            return result;
        }

        public int DeleteBrand(int id)
        {
            int result = 0;
            var model = _context.Brands.SingleOrDefault(x=>x.BrandID == id);
            if (model != null) 
            { 
              _context.Brands.Remove(model);
                result = _context.SaveChanges();
            }
            return result;
        }

        public Brand GetBrandById(int id)
        {
            var model = _context.Brands.Where(x => x.BrandID == id).SingleOrDefault();
            return model;
        }

        public IEnumerable<Brand> GetBrands()
        {
        return _context.Brands.ToList();    
        }

        public int UpdateBrand(Brand brand)
        {
            int result = 0;
          var model=_context.Brands.Where(x => x.BrandID ==brand.BrandID).SingleOrDefault();
            if (model != null)
            {
                model.BrandName = brand.BrandName;
                result = _context.SaveChanges();
            }
            return result ;
        }
        public void BulkInsertBrand(List<Brand> brands)
        {
            var model = brands.Select(m => new Brand
            {
                BrandName = m.BrandName,
               
            }).ToList();

            _context.Brands.AddRange(model);
            _context.SaveChanges();
        }

        public void BulkUpdateBrand(List<Brand> brands)
        {
            var brandFields = _context.Brands.ToList();

            foreach (var Brand in brands)
            {
                var brand = brandFields.FirstOrDefault(m => m.BrandID == Brand.BrandID);
                if (brand != null)
                {
                    brand.BrandName = brand.BrandName;                  
                }
            }

            _context.SaveChanges();
        }
    }
}
