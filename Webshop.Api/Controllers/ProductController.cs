using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webshop.Api.Models;
using Webshop.Api.Models.ModelDTO;
using Webshop.Api.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace Webshop.Api.Controllers
{
    [Route("/products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IEntityService<Product, int> _productService;
        private readonly IMapper _mapper;

        public ProductController(IEntityService<Product, int> productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "USER")]
        public IActionResult GetProducts()
        {
            return Ok(
                JsonSerializer.Serialize(
                    _productService.GetAll()
                        .Select(product => _mapper.Map<ProductDTO>(product))
                        .ToList()
                ));
        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetProduct(int id)
        {
            try
            {
                return Ok(
                    JsonSerializer.Serialize(
                        _mapper.Map<ProductDTO>(
                            _productService.GetById(id))
                    )
                );
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] ProductCreateDTO productCreateDTO)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid product");
            productCreateDTO.DateCreated = DateTime.Now.ToString();
            var product = _mapper.Map<Product>(productCreateDTO);
            try
            {
                _productService.Save(product);
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, "Server error: " + e);
            }



            return CreatedAtAction(nameof(GetProduct),
                new {id = 1},
                JsonSerializer.Serialize(
                    _mapper.Map<ProductDTO>(product))
            );
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.DeleteById(id);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit([FromBody] ProductUpdateDTO productUpdateDTO, int id)
        {
            if (id != productUpdateDTO.Id)
            {
                return BadRequest($"No product with id: {id}");
            }

            var product = _mapper.Map<Product>(productUpdateDTO);

            try
            {
                var updatedProduct = _productService.Edit(product);
                var updatedProductDto = _mapper.Map<ProductDTO>(updatedProduct);
                return Ok(
                    JsonSerializer.Serialize(
                        updatedProductDto
                        )
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