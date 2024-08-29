using ExtraaEdgeAssesment.Data;
using ExtraaEdgeAssesment.DTO;
using ExtraaEdgeAssesment.Models;
using ExtraaEdgeAssesment.Repository.Interfaces;

namespace ExtraaEdgeAssesment.Repository
{
    public class MobileRepository : IMobileRepository
    {
        private readonly ApplicationDbContext _context;
        public MobileRepository(ApplicationDbContext db)
        {
            this._context = db;
        }

        public int AddMobile(Mobile mobile)
        {
            int result = 0;
            _context.Mobiles.Add(mobile);
            result = _context.SaveChanges();
            return result;
        }

        public int DeleteMobile(int id)
        {
            int result = 0;
            var model = _context.Mobiles.SingleOrDefault(x => x.MobileID == id);
            if (model != null)
            {
                _context.Mobiles.Remove(model);
                result = _context.SaveChanges();
            }
            return result;
        }

        public Mobile GetMobileById(int id)
        {
            var model = _context.Mobiles.Where(x => x.MobileID == id).SingleOrDefault();
            return model;
        }

        public IEnumerable<Mobile> GetMobiles()
        {
            return _context.Mobiles.ToList();
        }

        public int UpdateMobile(Mobile mobile)
        {
            int result = 0;
            var model = _context.Mobiles.Where(x => x.MobileID == mobile.MobileID).SingleOrDefault();
            if (model != null)
            {
                model.BrandID = mobile.BrandID;
                model.ModelName = mobile.ModelName;
                model.Price = mobile.Price;
                result = _context.SaveChanges();
            }
            return result;
        }

        public void BulkInsertMobile(List<Mobile> mobiles)
        {
            var model = mobiles.Select(m => new Mobile
            {
                BrandID = m.BrandID,
                ModelName = m.ModelName,
                Price = m.Price
            }).ToList();

            _context.Mobiles.AddRange(model);
            _context.SaveChanges();
        }

        public void BulkUpdateMobile(List<Mobile> mobiles)
        {
            var mobileFields = _context.Mobiles
      .Where(m => mobiles.Select(n => n.MobileID).Contains(m.MobileID))
      .ToList();

            foreach (var mobile in mobiles)
            {
                var existingMobile = mobileFields.FirstOrDefault(m => m.MobileID == mobile.MobileID);
                if (existingMobile != null)
                {
                    existingMobile.BrandID = mobile.BrandID;
                    existingMobile.ModelName = mobile.ModelName;
                    existingMobile.Price = mobile.Price;
                }
            }

            _context.SaveChanges();
        }
     
    }
}
