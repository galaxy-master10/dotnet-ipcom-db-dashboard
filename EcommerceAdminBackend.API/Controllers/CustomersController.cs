using EcommerceAdminBackend.Domain.DTOs.Custom;
using EcommerceAdminBackend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EcommerceAdminBackend.Domain.Interfaces;
using EcommerceAdminBackend.Shared.Common.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace EcommerceAdminBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
      private readonly ICustomerService _customerService;
      
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [HttpGet]
        public async Task<ActionResult<PaginatedResponse<Customer>>> GetFilteredAsync(
            [FromQuery] CustomerFilterDto filter, int pageNumber = 1, int pageSize = 10)
        {
            var result = await _customerService.GetFilteredAsync(filter, pageNumber, pageSize);

            if (result.Data.Count == 0)
                return NotFound("No customers found matching the specified criteria.");

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetByIdAsync(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }
      
    }
}
