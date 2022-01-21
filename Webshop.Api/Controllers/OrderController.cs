using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webshop.Api.Models;
using Webshop.Api.Models.ModelsDTO;
using Webshop.Api.Service;

namespace Webshop.Api.Controllers
{
    [Route("/orders/")]
    [ApiController]
    public class OrderController : ControllerBase
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
        public ActionResult<List<OrderDTO>> GetOrders()
        {
            return _orderService.GetAll()
                    .Select(order => _mapper.Map<OrderDTO>(order))
                    .ToList();

        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<OrderDTO> GetOrder(int id)
        {
            try
            {
                return Ok(_mapper.Map<OrderDTO>(
                            _orderService.GetById(id))
                    
                );
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<OrderDTO> Create([FromBody] OrderCreateDTO orderCreateDto)
        {
            if (!ModelState.IsValid) return BadRequest("Bad order");
            Order order;
            try
            {
                var orderDto = _mapper.Map<OrderDTO>(orderCreateDto);
                order = _orderService.Save(_mapper.Map<Order>(orderDto));
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, "Server error: " + e);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Server error: " + e);
            }

            return CreatedAtAction(nameof(GetOrder),
                new {id = order.Id}, _mapper.Map<OrderDTO>(order)
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
        public ActionResult<OrderDTO> Edit([FromBody] OrderUpdateDTO orderUpdateDTO, int id)
        {
            if (id != orderUpdateDTO.Id)
            {
                return BadRequest($"No order with id: {id}");
            }

            var order = _mapper.Map<Order>(
                _mapper.Map<OrderDTO>(orderUpdateDTO)
                );
            try
            {
                return Ok(_mapper.Map<OrderDTO>(_orderService.Edit(order)));

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