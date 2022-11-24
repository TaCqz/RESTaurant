using RESTaurant.Entities;

namespace RESTaurant.Services
{
    // Service führen Datenverarbeitung für den Controller durch; Normalerweise werden Grundfunktionen (Default Find, Find, Create, Replace, Delete und ihre ID-Varianten)
    // in einer BaseService Klasse implementiert und vererbt
    public class DishService
    {
        public Dish GetDish(int id)
        {
            return MainContext.GetDishById(id);
        }
    }
}
