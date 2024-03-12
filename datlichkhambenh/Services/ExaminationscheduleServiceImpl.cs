using datlichkhambenh.Models;

namespace datlichkhambenh.Services
{
    public class ExaminationscheduleServiceImpl : ExaminationscheduleService
    {
        private DatabaseContext db;

        public ExaminationscheduleServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

		public bool Create(Lichkham lichkham)
		{
			try
			{
				db.Lichkhams.Add(lichkham);
				return db.SaveChanges() > 0;
			}
			catch
			{
				return false;
			}
		}

        public List<Lichkham> findAll()
        {
            return db.Lichkhams.ToList();
        }

        public List<Lichkham> findByDate(DateTime from, DateTime to)
        {
            return db.Lichkhams.Where(p => p.Ngaykham >= from && p.Ngaykham <= to).ToList();
        }

        public List<Lichkham> findById(int id)
        {
            return db.Lichkhams.Where(p => p.Mabn.Equals(id)).ToList();
        }
    }
}
