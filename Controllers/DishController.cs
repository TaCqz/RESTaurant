using Microsoft.AspNetCore.Mvc;
using RESTaurant.Entities;
using RESTaurant.Services;

namespace RESTaurant.Controllers
{
    // Der Controller nimmt die Request an der entsprechenden URL entgegen und wertet sie aus oder schickt sie an den Service weiter
    [ApiController]
    [Route("[controller]")]
    public class DishController : ControllerBase
    {
        // Service wird hier registriert. In größeren Anwendungen erfolgt die Anmeldung in der Program.cs (Startpunkt) zur Wahrung der
        // SOLID-Prinzipien
        private readonly ILogger<DishController> _logger;
        private readonly DishService Service = new();

        public DishController(ILogger<DishController> logger)
        {
            _logger = logger;
        }
        // Eine Post-Methode gibt in der Regel keinen Statuscode zurück. In diesem Beispiel führen wir keine Erstellung durch, sondern
        // werfen einfach den Statuscode "200 (OK)" aus. In einem richtigen Programm würde hier ein Datenbank-Insert aufgerufen und das
        // Eegebnis ausgewertet (Error von der Datenbank wirft dann einen HTTP 400 (BAD REQUEST), meldet die Datenbank einen erfolgreichen
        // Insert, kommt entsprechend ein HTTP 201 (CREATED)
        [HttpPost(Name = "Dish")]
        public IActionResult Post(Dish dish)
        {
            if (MainContext.AddNewDish(dish)) return Ok();
            return BadRequest();
        }
        [HttpDelete(Name = "Dish")]
        public IActionResult Delete(int id)
        {
            if (!MainContext.registeredDishes.ContainsKey(id)) return BadRequest();
            MainContext.Delete(id);
            return Ok();
        }

        [HttpPut(Name = "Dish")]
        public IActionResult Update(Dish dish)
        {
            if (!MainContext.registeredDishes.ContainsKey(dish.Id)) return BadRequest();

            MainContext.Update(dish);
            return Ok();
        }

        [HttpGet(Name = "Dish")]
        public Dish Get(int id, string? type)
        {
            Dish result = new();
            // Switch-Case um die Ausführung anhand des übergebenen Parameters zu bestimmen
            switch (type)
            {
                case "viaService":
                    // Aufruf an die entsprechende Methode im Service
                    result = Service.GetDish(id);
                    break;
                case "noService":
                    // Hier würde ein Datenbankaufruf stattfinden um die Daten zu lesen und anschließend zurückzugeben
                    result = MainContext.GetDishById(id);
                    break;
                default:
                    break;
            };
            // Das Ergebnis wird als JSON-Daten zurück gegeben
            return result;
        }
    }
}