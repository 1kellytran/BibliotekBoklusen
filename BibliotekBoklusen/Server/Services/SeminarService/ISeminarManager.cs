﻿namespace BibliotekBoklusen.Server.Services.SeminarService
{
    public interface ISeminarManager
    {
        Task<List<Seminarium>> GetAllSeminars();
        Task<Seminarium> GetSeminarById(int id);
        Task<Seminarium> CreateSeminar(Seminarium seminarToAdd);
        Task<Seminarium> UpdateSeminar(int id, Seminarium seminarToUpdate);
        Task<Seminarium> DeleteSeminar(int id);
    }
}
