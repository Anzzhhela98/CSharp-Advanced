namespace Christmas
{
    class Present
    {
        public Present(string name, double weight, string gender)
        {
            this.Name = name;
            this.Weight = weight;
            this.Gender = gender;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }

        public override string ToString()
        {
            return $"Present {Name} ({Weight}) for a {Gender}";
        }
    }
}
