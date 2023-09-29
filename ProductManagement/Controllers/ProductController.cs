using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;
using ProductManagement.Model;
using System.Collections.Generic;

namespace ProductManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private ProductManagementContext _db;
    public ProductsController(ProductManagementContext db)
    {
        _db = db;
    }

    [HttpGet]
    [Route("",Name = "GetAllProducts")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return await _db.Product.ToListAsync() is List<Product> model? Ok(model): NotFound();
        }
        catch (Exception)
        {
            return BadRequest("Products not Found");
        }
    }

    [HttpGet]
    [Route("{id}", Name = "GetProductById")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            return await _db.Product.FindAsync(id)
                is Product model
                    ? Ok(model)
                    : NotFound();
        }
        catch (Exception)
        {
            return BadRequest("Please send a valid Id");
        }
    }

    [HttpPost]
    [Route("", Name = "CreateProduct")]
    public async Task<IActionResult> Post(Product product)
    {
        try
        {
            _db.Product.Add(product);
            await _db.SaveChangesAsync();
            return Created($"/Products/{product.Id}", product);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }

    }

    [HttpPut]
    [Route("{id}", Name = "UpdateProduct")]
    public async Task<IActionResult> Put(int id, Product product)
    {
        try
        {
            var foundModel = await _db.Product.FindAsync(id);

            if (foundModel is null)
            {
                return NotFound();
            }

            foundModel.Name=product.Name;
            _db.Update(foundModel);

            await _db.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }

    }

    [HttpDelete]
    [Route("", Name = "DeleteProduct")]
    public async Task<IActionResult> Delete(int Id)
    {
        try
        {
            if (await _db.Product.FindAsync(Id) is Product product)
            {
                _db.Product.Remove(product);
                await _db.SaveChangesAsync();
                return Ok(product);
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }
}