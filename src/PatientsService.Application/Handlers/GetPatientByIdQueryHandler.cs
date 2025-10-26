using MediatR;
using PatientsService.Application.Queries;
using PatientsService.Domain.Entities;
using PatientsService.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PatientsService.Application.Handlers
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Patient?>
    {
        private readonly IPatientRepository _repository;

        public GetPatientByIdQueryHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public Task<Patient?> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repository.GetById(request.Id));
        }
    }
}
