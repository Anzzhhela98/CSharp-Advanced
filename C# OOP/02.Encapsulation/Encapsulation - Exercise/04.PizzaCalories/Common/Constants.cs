namespace _04.PizzaCalories.Common
{
    public static class Constants
    {
        public static string InavalidArgumentOfDough =
            "Invalid type of dough.";
        public static string InvalidOperationForGramOfDough =
            "Dough weight should be in the range[{0}..{1}].";
        public static string InavalidArgumentOfTopping =
          "Cannot place {0} on top of your pizza.";
        public static string InvalidOperationForGramOfTopping =
       "{0} weight should be in the range [{1}..{2}].";
        public static string InvalidOperationForToppingCount = 
            "Number of toppings should be in range [{0}..{1}].";
        public static string InvalidArgumentLenghtOfPizzaName =
            "Pizza name should be between {0} and {1} symbols.";

        public const double MIN_CALORIES_PER_GRAM = 2;
        public const double MIN_WEIGHT_FOR_DOUGH = 1;
        public const double MAX_WEIGHT_FOR_DOUGH = 200;

        public const double MIN_WEIGHT_FOR_TOPPING = 1;
        public const double MAX_WEIGHT_FOR_TOPPING= 50;

        public const int MAX_COUNT_OF_TOPPINGS = 10;

        public const int MAX_LENGHT_OF_PIZZA_NAME = 15;
        public const int MIN_LENGHT_OF_PIZZA_NAME = 1;
    }
}
