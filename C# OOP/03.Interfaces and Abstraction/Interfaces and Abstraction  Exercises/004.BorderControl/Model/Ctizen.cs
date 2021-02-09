using System;
using System.Collections.Generic;
using System.Text;

namespace _004.BorderControl
{
    public class Ctizen : IIDValidatorable
    {
        public Ctizen(string name, int age, string iD)
        {
            this.Name = name;
            this.Age = age;
            this.ID = iD;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string ID { get; set; }

        //public string CheckLastDigit(string ID)
        //{

        //    return ID;
        //}
        public override string ToString() => $"{this.ID}";
    }
}
