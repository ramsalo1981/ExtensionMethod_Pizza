namespace CAExtentionMethod_Pizza
{
    public class Program
    {
        static void Main(string[] args)
        {
           Pizza p = new Pizza();
            //p = PizzaExtension.AddDough(PizzaExtension.AddSauce(PizzaExtension.AddCheeze(PizzaExtension.AddToppings(p, "black olives", 3.5m), true)), "thin");
            //Console.WriteLine(p);

            p.AddDough("thin")
              .AddSauce()
              .AddCheeze(true)
              .AddToppings("black olives", 3.5m);

            Console.WriteLine(p);
        }
    }

     static class PizzaExtension
    {
        public static Pizza AddDough(this Pizza value, string type)
        {
            value.Content += $"\n{type} Dough X $4.00";
            value.TotalPrice += 4m;
            return value ;
        }
        public static Pizza AddSauce(this Pizza value)
        {
            value.Content += $"\nTomato Sauce X $2.00";
            value.TotalPrice += 2m;
            return value;
        }
        public static Pizza AddCheeze(this Pizza value, bool extra)
        {
            value.Content += $"\n{(extra ? "extra" : "regular")} Cheeze Sauce X ${(extra ? "6.00" : "4.00")}";
            value.TotalPrice += extra ? 6m : 4m;
            return value;
        }
        public static Pizza AddToppings(this Pizza value, string type, decimal price)
        {
            value.Content += $"\n{type} X ${price.ToString("#.##")}";
            value.TotalPrice += price;
            return value;
        }
    }

     class Pizza
    {
        public string Content { get; set; }
        public decimal TotalPrice { get; set; }


        public override string ToString()
        {
            return $"{Content}\n-----------------------\nTotal Price: ${TotalPrice.ToString("#.##")}";
        }
    }
}