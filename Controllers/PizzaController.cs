using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;


namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaService _service;
      
        public PizzaController(PizzaService service)
        {            
            _service = service;
        }
        // Get all action
        [HttpGet]
        public IEnumerable<Pizza> GetAll() => _service.GetAll();   

        // Get by Id action
        [HttpGet("{id}")]
        public ActionResult<Pizza> GetById(int id) {
            var pizza = _service.GetById(id);
            if(pizza is null) return NotFound();
            return pizza;
        }

        // Post Action
        [HttpPost]
        public IActionResult Create(Pizza newPizza){
            var pizza = _service.Create(newPizza);
            return CreatedAtAction(nameof(GetById), new { id = pizza!.Id}, pizza);
        }

        // Put action
        [HttpPut("{id}/addtopping")]
        public IActionResult AddTopping(int id, int toppingId){

            // check to see if there is a pizza has that giving id
            var pizzaToUpdate = _service.GetById(id);
            if(pizzaToUpdate is not null){
                _service.AddTopping(id, toppingId);
                return NoContent();
            }else{
                 return NotFound();
            }
        }

        [HttpPut("{id}/updatesauce")]
        public IActionResult UpdateSauce(int id, int sauceid){

            // check to see if there is a pizza has that giving id
            var pizzaToUpdate = _service.GetById(id);
            if(pizzaToUpdate is not null){
                _service.UpdateSauce(id, sauceid);
                return NoContent();
            }else{
                 return NotFound();
            }
        }

        // Delete action
        [HttpDelete("{id}")]   
        public IActionResult Delete(int id){
            var pizza = _service.GetById(id);
            if(pizza is null) return NotFound();
            _service.DeleteById(id);
            return NoContent();
        }
    }
}