using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.API.Commands;

public class UpdateDriverInfoRequest : IRequest<bool>
{
    public UpdateDriverRequest Driver { get; set; }

    public UpdateDriverInfoRequest(UpdateDriverRequest driver)
    {
        Driver = driver;
    }
}