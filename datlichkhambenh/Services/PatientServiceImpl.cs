using datlichkhambenh.Models;

namespace datlichkhambenh.Services
{
	public class PatientServiceImpl : PatientService
	{
		private DatabaseContext db;

		public PatientServiceImpl(DatabaseContext _db)
		{
			db = _db;
		}

		public List<Benhnhan> findAll()
		{
			return db.Benhnhans.ToList();
		}

		public List<Benhnhan> findById(int mabn)
		{
			return db.Benhnhans.Where(p=>p.Mabn.Equals(mabn)).ToList();
        }

        public Benhnhan findByName(string name)
        {
            return db.Benhnhans.Find(name);
        }

        public bool Create(Benhnhan benhnhan)
        {
            try
            {
                db.Benhnhans.Add(benhnhan);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Login(string username, string password)
        {
            var account = db.Benhnhans.SingleOrDefault(a => a.Account == username && a.Password == password);
            if (account != null)
            {
                return true;
            }
            return false;
        }

        public List<Benhnhan> findByAcc(string acc)
        {
            return db.Benhnhans.Where(p => p.Account.Equals(acc)).ToList();
        }
    }
}
