using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _loger;
        private readonly DataContext _Context;

        public ProductosController(ILogger<ProductosController> logger, DataContext context)
        {
            _loger = logger;
            _Context = context;
        }
        [HttpGet(Name = "GetProductos")]
        public async Task<ActionResult<IEnumerable<producto>>> GetProductos()
        {
            return await _Context.productos.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetProducto")]
        public async Task<ActionResult<producto>> GetProducto(int id)
        {
            var producto = await _Context.productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]

        public async Task<ActionResult<producto>> Post(producto producto)
        {
            _Context.productos.Add(producto);
            await _Context.SaveChangesAsync();

            return new CreatedAtRouteResult("Getproducto", new { id = producto.Id}, producto);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Put(int id, producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }
            _Context.Entry(producto).State = EntityState.Modified;
            await _Context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<producto>> Delete(int id)
        {
            var producto = await _Context.productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _Context.Remove(producto);
            await _Context.SaveChangesAsync();

            return producto;
        }
    }
}