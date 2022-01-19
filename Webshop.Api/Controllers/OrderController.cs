using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShopApp.Models;
using WebShopApp.Models.ModelsDTO;
using WebShopApp.Service;

namespace WebShopApp.Controllers
{
    [Route("/orders/")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IEntityService<Order, int> _orderService;
        private readonly IMapper _mapper;

        public OrderController(IEntityService<Order, int> orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "USER")]
        public IActionResult GetOrders()
        {
            return Ok(
                JsonSerializer.Serialize(
                _orderService.GetAll()
                .Select(order => _mapper.Map<OrderDTO>(order))
                .ToList()
                    )
                );
        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetOrder(int id)
        {
            try
            {
                return Ok(
                    JsonSerializer.Serialize(
                        _mapper.Map<OrderDTO>(
                            _orderService.GetById(id))
                    )
                );
            }
            catch (KeyNotFoundException e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("")]
        public IActionResult Create([FromBody] OrderCreateDTO orderCreateDTO)
        {
            var order = _mapper.Map<Order>(orderCreateDTO);
            if (ModelState.IsValid)
            {
                try
                {
                    _orderService.Save(order);
                }
                catch (DbUpdateException e)
                {
                    return StatusCode(500, "Server error: " + e);
                }
            }
            return CreatedAtAction(nameof(GetOrder),
                new { id = order.Id },
                JsonSerializer.Serialize(
                    _mapper.Map<OrderDTO>(order))
                );
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _orderService.DeleteById(id);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            return NoContent();

        }

        [HttpPut]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromBody] OrderUpdateDTO orderUpdateDTO, int id)
        {
            if (id != orderUpdateDTO.Id)
            {
                return BadRequest($"No order with id: {id}");
            }
            var order = _mapper.Map<Order>(orderUpdateDTO);

            try
            {
                return Ok(
                    JsonSerializer.Serialize(
                        _orderService.Edit(order))
                    );
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, "Server error: " + e);
            }
        }
    
    }
}
