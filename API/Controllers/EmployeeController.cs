using API.Dtos.EmployeeDTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EmployeeController :BaseApiController
{
    public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, mapper)
    {

    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public async Task<ActionResult> AddEmployee(EmployeeDto model)
    {
        var employee =  _mapper.Map<Employee>(model);
        _unitOfWork.Employees.Add(employee);
        _unitOfWork.SaveAsync();

         return Ok(CreatedAtAction(nameof(AddEmployee), new {id = employee.Emp_NoId},employee));
        
    }
}