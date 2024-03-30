using MediatR;

namespace FormulaOne.API.Commands;

public class DeleteDriverInfoRequest : IRequest<bool>
{
    public Guid DriverId { get; set; }

    public DeleteDriverInfoRequest(Guid driverId)
    {
        DriverId = driverId;
    }
}