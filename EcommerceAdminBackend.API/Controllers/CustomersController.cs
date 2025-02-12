using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceAdminBackend.API.Data;
using EcommerceAdminBackend.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceAdminBackend.API.Services;

namespace EcommerceAdminBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
      private readonly ICustomerService _customerService;
      
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        } 
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        
        [HttpGet("customerid/{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomerByCustomerId(int customerId)
        {
            var customer = await _customerService.GetCustomerByCustomerIdAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        
        [HttpGet("customercontactid/{customerContactId}")]
        public async Task<ActionResult<Customer>> GetCustomerByCustomerContactId(int customerContactId)
        {
            var customer = await _customerService.GetCustomerByCustomerContactIdAsync(customerContactId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        
        [HttpGet("sourceid/{sourceId}")]
        public async Task<ActionResult<Customer>> GetCustomerBySourceId(string sourceId)
        {
            var customer = await _customerService.GetCustomerBySourceIdAsync(sourceId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        
        [HttpGet("vatnumber/{vatNumber}")]
        public async Task<ActionResult<Customer>> GetCustomerByVatNumber(string vatNumber)
        {
            var customer = await _customerService.GetCustomerByVatNumberAsync(vatNumber);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        
        [HttpGet("email/{email}")]
        public async Task<ActionResult<Customer>> GetCustomerByEmail(string email)
        {
            var customer = await _customerService.GetCustomerByEmailAsync(email);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        
        [HttpGet("mobile/{mobile}")]
        public async Task<ActionResult<Customer>> GetCustomerByMobile(string mobile)
        {
            var customer = await _customerService.GetCustomerByMobileAsync(mobile);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        
        [HttpGet("web/{web}")]
        public async Task<ActionResult<Customer>> GetCustomerByWeb(string web)
        {
            var customer = await _customerService.GetCustomerByWebAsync(web);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        
        [HttpGet("firstname/{firstName}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersByFirstName(string firstName)
        {
            var customers = await _customerService.GetCustomersByFirstNameAsync(firstName);
            return Ok(customers);
        }
        
        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersByName(string name)
        {
            var customers = await _customerService.GetCustomersByNameAsync(name);
            return Ok(customers);
        }
        
        [HttpGet("language/{language}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersByLanguage(string language)
        {
            var customers = await _customerService.GetCustomersByLanguageAsync(language);
            return Ok(customers);
        }
        
        [HttpGet("addressstreet/{addressStreet}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersByAddressStreet(string addressStreet)
        {
            var customers = await _customerService.GetCustomersByAddressStreetAsync(addressStreet);
            return Ok(customers);
        }
        
        [HttpGet("addressnumber/{addressNumber}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersByAddressNumber(string addressNumber)
        {
            var customers = await _customerService.GetCustomersByAddressNumberAsync(addressNumber);
            return Ok(customers);
        }
        
        [HttpGet("addresspostalcode/{addressPostalCode}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersByAddressPostalCode(string addressPostalCode)
        {
            var customers = await _customerService.GetCustomersByAddressPostalCodeAsync(addressPostalCode);
            return Ok(customers);
        }
        
        [HttpGet("addresscity/{addressCity}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersByAddressCity(string addressCity)
        {
            var customers = await _customerService.GetCustomersByAddressCityAsync(addressCity);
            return Ok(customers);
        }
        
        [HttpGet("addresscountry/{addressCountry}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersByAddressCountry(string addressCountry)
        {
            var customers = await _customerService.GetCustomersByAddressCountryAsync(addressCountry);
            return Ok(customers);
        }
        
        [HttpGet("createdts/{createdTS}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersByCreatedTS(DateTime createdTS)
        {
            var customers = await _customerService.GetCustomersByCreatedTSAsync(createdTS);
            return Ok(customers);
        }
        
        
      
    }
}
