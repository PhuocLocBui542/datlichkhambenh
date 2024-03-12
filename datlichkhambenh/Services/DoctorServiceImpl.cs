using datlichkhambenh.Models;

namespace datlichkhambenh.Services
{
	public class DoctorServiceImpl : DoctorService
    {
        private DatabaseContext db;

        public DoctorServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public bool Create(Bacsi bacsi)
        {
            try
            {
                db.Bacsis.Add(bacsi);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int mabs)
        {
            try
            {
                db.Bacsis.Remove(findById(mabs));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Bacsi> findAll()
        {
            return db.Bacsis.ToList();
        }

        public Bacsi findById(int mabs)
        {
            return db.Bacsis.Find(mabs);
        }

		public Bacsi findByName(string name)
		{
			return db.Bacsis.Find(name);
		}

		public bool Update(Bacsi bacsi)
        {
            try
            {
                db.Entry(bacsi).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
