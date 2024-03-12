using datlichkhambenh.Models;

namespace datlichkhambenh.Services
{
    public interface ExaminationscheduleService
    {
        public List<Lichkham> findAll();
        public List<Lichkham> findById(int id);
        public List<Lichkham> findByDate(DateTime from, DateTime to);
		public bool Create(Lichkham lichkham);
	}
}
