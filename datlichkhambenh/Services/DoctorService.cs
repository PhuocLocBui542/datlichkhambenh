using datlichkhambenh.Models;

namespace datlichkhambenh.Services
{
    public interface DoctorService
    {
        public List<Bacsi> findAll();
        public Bacsi findById(int mabs);
        public Bacsi findByName(string name);
        public bool Create(Bacsi bacsi);
        public bool Update(Bacsi bacsi);
        public bool Delete(int mabs);
    }
}
