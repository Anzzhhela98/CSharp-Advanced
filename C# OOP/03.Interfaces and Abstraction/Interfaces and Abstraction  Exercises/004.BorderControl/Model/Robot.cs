using System;
using System.Collections.Generic;
using System.Text;

namespace _004.BorderControl
{
    public class Robot : IIDValidatorable
    {
        public Robot(string model, string iD)
        {
           this. Model = model;
           this. ID = iD;
        }

        public string Model { get; private set; }
        public string ID { get; set; }

        //public string CheckLastDigit(string ID)
        //{
        //    return ID;
        //}
        public override string ToString() => $"{this.ID}";
    }
}
