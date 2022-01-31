using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webshop.Api.Models;
using Webshop.Api.Models.ModelDTO;
using Webshop.Api.Models.ModelsDTO;
using Webshop.Api.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webshop.Api.Controllers
{
    [Route("/customers/")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : Controller
    {
        private readonly IEntityService<Customer, string> _customerService;
        private readonly IMapper _mapper;

        public CustomerController(IEntityService<Customer, string> customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public ActionResult<ICollection<CustomerDTO>> GetCustomers()
        {
            return
                Ok(
                _customerService.GetAll()
                    .Select(customer => _mapper.Map<CustomerDTO>(customer))
                    .ToList());
        }

        
        
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public ActionResult<CustomerDTO> GetCustomer(string id)
        {
            try
            {
                return Ok(
                        _mapper.Map<CustomerDTO>(
                        _customerService.GetById(id))
                );
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

       
        [HttpPost]
//        [ValidateAntiForgeryToken]
        [Route("")]
        [Authorize(Roles = "User,Admin")]
        public ActionResult<CustomerDTO> Create([FromBody] CustomerCreateDTO customerCreateDTO)
        {
            if (!ModelState.IsValid) return BadRequest();

            var customer = _mapper.Map<Customer>(customerCreateDTO);

            try
            {
                _customerService.Save(customer);
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, "Server error: " + e);
            }

            return Created("", _mapper.Map<CustomerDTO>(customer));
        }

        
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult Delete(string id)
        {
            try
            {
                _customerService.DeleteById(id);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e);
            }

            return NoContent();
        }

        
        [HttpPut]
        [Route("{id}")]
//        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User,Admin")]
        public ActionResult<CustomerDTO> Edit([FromBody] CustomerUpdateDTO customerUpdateDTO, string id)
        {
            if (id != customerUpdateDTO.Id)
            {
                return BadRequest($"No product with id: {id}");
            }

            customerUpdateDTO.NormalizedEmail = customerUpdateDTO.Email.ToUpper();

            var customer = _mapper.Map<Customer>(customerUpdateDTO);

            try
            {
                return Ok(
                        _mapper.Map<CustomerDTO>(_customerService.Edit(customer))
                    );
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e);
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, "Server error: " + e);
            }
        }

    }
}
