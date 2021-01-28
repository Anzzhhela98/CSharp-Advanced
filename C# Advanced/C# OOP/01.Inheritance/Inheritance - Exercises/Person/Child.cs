using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    class Child : Person
    {
        public Child(string name, int age)
           : base(name, age)
        {

        }
        public override int Age
        {
            get { return base.Age; }
            protected set
            {
                if (value>15)
                {
                    throw new ArgumentException("Child age cannot be more than 15");
                }
                base.Age = value;
            }
        }
    }
}
