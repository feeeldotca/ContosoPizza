using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : Controller
    {
      
        public PizzaController()
        {            
        }
        // Get all action
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();   

        // Get by Id action
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id) {
            var pizza = PizzaService.Get(id);
            if(pizza is null) return NotFound();
            return pizza;
        }
        // Post Action
        [HttpPost]
        public IActionResult Create(Pizza pizza){
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.Id}, pizza);
        }

        // Put action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza){
            // check to see if giving pizza id equals the giving id.
            if(pizza.Id != id) return BadRequest();
            
            // check to see if there is a pizza has that giving id
            var pizzaRequested = PizzaService.Get(id);
            if(pizzaRequested is null) return NotFound();

            PizzaService.Update(id, pizza);
            return NoContent();

        }

        // Delete action
        [HttpDelete("{id}")]   
        public IActionResult Delete(int id){
            var pizza = PizzaService.Get(id);
            if(pizza is null) return NotFound();
            PizzaService.Delete(id);
            return NoContent();
        }
    }
}