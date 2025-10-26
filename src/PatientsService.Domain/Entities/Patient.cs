using System;

namespace PatientsService.Domain.Entities
{

    /// <summary>
    /// Patient entity
    /// </summary>
    public class Patient
    {
        public int Id { get; set; }
        public string NHSNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string GPPractice { get; set; } = string.Empty;
    }
}
