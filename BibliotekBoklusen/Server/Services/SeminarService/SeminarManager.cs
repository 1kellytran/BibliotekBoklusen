namespace BibliotekBoklusen.Server.Services.SeminarService
{
    public class SeminarManager : ISeminarManager
    {
        private readonly AppDbContext _context;
        public SeminarManager(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Seminarium>> GetAllSeminars()
        {
            var seminar = _context.Seminariums.ToList();

            if (seminar == null)
            {
                return null;
            }
            return seminar;
        }

        public async Task<Seminarium> GetSeminarById(int id)
        {
            var seminar = _context.Seminariums.FirstOrDefault(s => s.Id == id);
            
            if(seminar == null)
            {
                return null;
            }
            return seminar;
        }

        public async Task<Seminarium> CreateSeminar(Seminarium seminarToAdd)
        {
            if (seminarToAdd != null)
            {
                _context.Seminariums.Add(seminarToAdd);
                await _context.SaveChangesAsync();

                return seminarToAdd;
            }
            return null;
        }

        public async Task<Seminarium> UpdateSeminar(int id, Seminarium seminarToUpdate)
        {
            var seminar = _context.Seminariums.FirstOrDefault(s => s.Id == id);

            if(seminar != null)
            {
                seminar.Title = seminarToUpdate.Title;
                seminar.FirstName = seminarToUpdate.FirstName;
                seminar.LastName = seminarToUpdate.LastName;
                seminar.DayAndTime = seminarToUpdate.DayAndTime;
                await _context.SaveChangesAsync();

                return seminarToUpdate;
            }
            return null;
        }

        public async Task<Seminarium> DeleteSeminar(int id)
        {
            var seminar = _context.Seminariums.FirstOrDefault(s => s.Id == id);

            if(seminar != null)
            {
                _context.Seminariums.Remove(seminar);
                await _context.SaveChangesAsync();
            }
            return null;
        }
    }
}
