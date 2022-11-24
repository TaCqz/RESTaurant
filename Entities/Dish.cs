using System.ComponentModel.DataAnnotations.Schema;

namespace RESTaurant.Entities
{
    // Ein ganz normales Modell
    public class Dish
    {
        // Felder in Datenbanken würden so dargestellt werden:
        //[Key] oder
        //[Column] oder
        //[Not Mapped]
        public int Id { get; set; }
        public string? DatePrepared { get; set; }

        public float Price { get; set; }

        public string? KochName { get; set; }

        public string? Name { get; set; }
    }
}