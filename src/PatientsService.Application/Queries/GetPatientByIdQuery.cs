using MediatR;
using PatientsService.Domain.Entities;

namespace PatientsService.Application.Queries
{
    public record GetPatientByIdQuery(int Id) : IRequest<Patient?>;
}
