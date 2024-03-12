using datlichkhambenh.Models;

namespace datlichkhambenh.Services
{
	public class DepartmentServiceImpl : DepartmentService
	{
		private DatabaseContext db;

		public DepartmentServiceImpl(DatabaseContext _db)
		{
			db = _db;
		}

        public bool Create(Khoa khoa)
        {
            try
            {
                db.Khoas.Add(khoa);
                return db.SaveChanges() > 0;
            }
            catch 
            {
                return false;
            }
        }
        public Khoa findById(int makhoa)
        {
            return db.Khoas.Find(makhoa);
        }

        public bool Delete(int makhoa)
        {
            try
            {
                db.Khoas.Remove(findById(makhoa));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Khoa> findAll()
		{
			return db.Khoas.ToList();
		}


        public bool Update(Khoa khoa)
        {
            try
            {
                db.Entry(khoa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
