using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.API.Commands;

public class CreateDriverInfoRequest : IRequest<GetDriverResponse>
{
    public CreateDriverRequest DriverRequest { get; }

    public CreateDriverInfoRequest(CreateDriverRequest createDriverRequest)
    {
        DriverRequest = createDriverRequest;
    }
}