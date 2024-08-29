using ExtraaEdgeAssesment.DTO;
using ExtraaEdgeAssesment.Models;

namespace ExtraaEdgeAssesment.Repository.Interfaces
{
    public interface IMobileRepository
    {
        IEnumerable<Mobile> GetMobiles();
        Mobile GetMobileById(int id);
        int AddMobile(Mobile mobile);
        int UpdateMobile(Mobile mobile);
        int DeleteMobile(int id);
        public void BulkInsertMobile(List<Mobile> mobiles);
        public void BulkUpdateMobile(List<Mobile> mobiles);
       
    }
}
