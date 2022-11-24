using RESTaurant.Entities;

namespace RESTaurant
{
    public static class MainContext
    {

        public static Dictionary<int, Dish> registeredDishes = new();
        public static Dish GetDishById(int id)
        {
            if (!registeredDishes.ContainsKey(id)) return new Dish();
            return registeredDishes[id];
        }

        public static Dictionary<int, Dish> GetAllDishes()
        {
            return registeredDishes;
        }

        public static bool AddNewDish(Dish dish)
        {
            if (registeredDishes.ContainsKey(dish.Id)) return false;
            else
            {
                registeredDishes.Add(dish.Id, dish);
                return true;
            }
        }
        public static void Delete(int id)
        {
            registeredDishes.Remove(id);
        }
        public static void Update(Dish dish)
        {
            Dish input = new Dish();
            input.Id = dish.Id;
            if (dish.DatePrepared == null) input.DatePrepared = registeredDishes[dish.Id].DatePrepared;
            else input.DatePrepared = dish.DatePrepared;
            if (dish.KochName == null) input.KochName = registeredDishes[dish.Id].KochName;
            else input.KochName = dish.KochName;
            if (dish.Name == null) input.Name = registeredDishes[dish.Id].Name;
            else input.Name = dish.Name;
            if (dish.Price == null) input.Price = registeredDishes[dish.Id].Price;
            else input.Price = dish.Price;
            registeredDishes[dish.Id] = input;
        }

        public static void InitStartingValues()
        {
            Dish spagh = new Dish();
            spagh.Id = 1;
            spagh.DatePrepared = DateTime.Now.ToShortDateString();
            spagh.Price = 8.99f;
            spagh.KochName = "Chef Mike aka. die Mikrowelle";
            spagh.Name = "Spaghetti Bolognese";
            registeredDishes.Add(spagh.Id, spagh);

            Dish pie = new Dish();
            pie.Id = 2;
            pie.DatePrepared = DateTime.Now.ToShortDateString();
            pie.Price = 4.99f;
            pie.KochName = "Grodon Ramsay";
            pie.Name = "Kuchen halt ??";
            registeredDishes.Add(pie.Id, pie);

            Dish stew = new Dish();
            stew.Id = 3;
            stew.DatePrepared = DateTime.Now.ToShortDateString();
            stew.Price = 2.99f;
            stew.KochName = "Frank Rosine";
            stew.Name = "Suppe aus Moos";
            registeredDishes.Add(stew.Id, stew);

        }
    }
}
