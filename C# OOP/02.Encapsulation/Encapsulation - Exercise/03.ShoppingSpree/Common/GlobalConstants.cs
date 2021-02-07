using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree.Common
{
    public static class GlobalConstants
    {
        public static string InvalidInputNameExeptionMessage =
            "{0} cannot be empty";
        public static string InvalidMoneyExeptionMessage =
            "{0} cannot be negative";
        public static string InsufficientMoneyExeptionMessage =
            "{0} can't afford {1}";
        public const decimal COST_MIN_VALUE = 0;
    }
}
