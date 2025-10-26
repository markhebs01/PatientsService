using PatientsService.Domain.Entities;
using System.Collections.Generic;

namespace PatientsService.Domain.Interfaces
{
    public interface IPatientRepository
    {
        Patient? GetById(int id);
        IEnumerable<Patient> GetAll();
    }
}
