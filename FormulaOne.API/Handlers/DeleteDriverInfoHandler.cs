using AutoMapper;
using FormulaOne.API.Commands;
using FormulaOne.DataService.Resositories.Interfaces;
using MediatR;

namespace FormulaOne.API.Handlers;

public class DeleteDriverInfoHandler : IRequestHandler<DeleteDriverInfoRequest,bool>
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteDriverInfoHandler
    (
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteDriverInfoRequest request, CancellationToken cancellationToken)
    {
        var driver = await _unitOfWork.Drivers.GetById(request.DriverId);

        if (driver == null)
            return false;

        await _unitOfWork.Drivers.Delete(request.DriverId);
        await _unitOfWork.CompleteAsync();

        return true;
    }
}