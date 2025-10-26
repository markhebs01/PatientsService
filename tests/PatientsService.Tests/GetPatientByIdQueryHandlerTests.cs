using PatientsService.Application.Handlers;
using PatientsService.Application.Queries;
using PatientsService.Infrastructure.Repositories;
using System.Threading.Tasks;
using Xunit;

public class GetPatientByIdQueryHandlerTests
{
    [Fact]
    public async Task ReturnsPatient_WhenFound()
    {
        var repo = new InMemoryPatientRepository();
        var handler = new GetPatientByIdQueryHandler(repo);

        var result = await handler.Handle(new GetPatientByIdQuery(1), default);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }


    [Fact]
    public async Task ReturnsNull_WhenNotFound()
    {
        var repo = new InMemoryPatientRepository();
        var handler = new GetPatientByIdQueryHandler(repo);

        var result = await handler.Handle(new GetPatientByIdQuery(999), default);

        Assert.Null(result);
    }
}
