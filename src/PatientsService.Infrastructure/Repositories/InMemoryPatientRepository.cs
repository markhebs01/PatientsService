using PatientsService.Domain.Entities;
using PatientsService.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PatientsService.Infrastructure.Repositories
{
    public class InMemoryPatientRepository : IPatientRepository
    {


        //IN-MEMORY PATIENT DATA
        private readonly List<Patient> _patients = new()
        {
            new Patient { Id = 1, NHSNumber = "1234567890", Name = "Alice Johnson", DateOfBirth = new(1985,1,23), GPPractice = "NHS Northumbria" },
            new Patient { Id = 2, NHSNumber = "0987654321", Name = "Brian Carter", DateOfBirth = new(1990,3,14), GPPractice = "The Green House Surgery" },
            new Patient { Id = 3, NHSNumber = "1122334455", Name = "Catherine Lee", DateOfBirth = new(1978,7,2), GPPractice = "Betts Avenue Medical Centre" },
            new Patient { Id = 4, NHSNumber = "2233445566", Name = "David Thompson", DateOfBirth = new(1963,11,18), GPPractice = "Galleries Medical Practice" },
            new Patient { Id = 5, NHSNumber = "3344556677", Name = "Emma Wilson", DateOfBirth = new(1988,5,30), GPPractice = "Newcastle Medical Centre" }
        };


        //GET PATIENT BY ID
        public Patient? GetById(int id) => _patients.FirstOrDefault(p => p.Id == id);


        //GET ALL PATIENTS
        public IEnumerable<Patient> GetAll() => _patients;

    }
}
