using System;


namespace DateModifier
{
    public class DateModifier
    {

        public double CalculateDifferenceBetweenDates(string firstParameters,
            string secondParameters)
        {
            DateTime firt = Convert.ToDateTime(firstParameters);
            DateTime second = Convert.ToDateTime(secondParameters);

            double diff = Math.Abs((second - firt).Days);

            return diff;
        }
    }
}
