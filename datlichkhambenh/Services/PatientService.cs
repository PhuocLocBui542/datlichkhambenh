using datlichkhambenh.Models;

namespace datlichkhambenh.Services
{
	public interface PatientService
	{
		public List<Benhnhan> findById(int mabn);
		public List<Benhnhan> findByAcc(string acc);
		public Benhnhan findByName(string name);
		public List<Benhnhan> findAll();
        public bool Create(Benhnhan benhnhan);
        public bool Login(string username, string password);
    }
}
