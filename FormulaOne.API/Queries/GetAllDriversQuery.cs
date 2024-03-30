using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.API.Queries;

public class GetAllDriversQuery : IRequest<IEnumerable<GetDriverResponse>>
{
    
}