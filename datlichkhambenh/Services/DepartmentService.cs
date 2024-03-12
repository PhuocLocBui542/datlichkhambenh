using datlichkhambenh.Models;

namespace datlichkhambenh.Services
{
	public interface DepartmentService
	{
		public List<Khoa> findAll();
		public Khoa findById(int makhoa);
		public bool Create(Khoa khoa);
		public bool Update(Khoa khoa);
		public bool Delete(int makhoa);
	}
}
