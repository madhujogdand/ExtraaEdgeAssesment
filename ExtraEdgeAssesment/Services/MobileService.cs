using ExtraaEdgeAssesment.DTO;
using ExtraaEdgeAssesment.Models;
using ExtraaEdgeAssesment.Repository.Interfaces;
using ExtraaEdgeAssesment.Services.Interfaces;
using ExtraaEdgeAssesnment.Repository.Interfaces;

namespace ExtraaEdgeAssesment.Services
{
    public class MobileService : IMobileService
    {
        private readonly IMobileRepository repo;
        public MobileService(IMobileRepository repo)
        {
            this.repo = repo;
        }

        public int AddMobile(Mobile mobile)
        {
          return repo.AddMobile(mobile);
        }

        public int DeleteMobile(int id)
        {
          return repo.DeleteMobile(id);
        }

        public Mobile GetMobileById(int id)
        {
           return repo.GetMobileById(id);
        }

        public IEnumerable<Mobile> GetMobiles()
        {
          return repo.GetMobiles();
        }

        public int UpdateMobile(Mobile mobile)
        {
          return repo.UpdateMobile(mobile);
        }

        public void BulkInsertMobile(List<Mobile> mobiles)
        {
             repo.BulkInsertMobile(mobiles);    
        }

        public void BulkUpdateMobile(List<Mobile> mobiles)
        {
            repo.BulkUpdateMobile(mobiles);
        }
     
    }
}
