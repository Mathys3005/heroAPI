namespace heroAPI.Models
{
    public class Power
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PowerId { get; set; }

        public int HeroId { get; set; }
        public virtual Hero Hero { get; set; }

        public Power()
        {
        }

        public Power(int PowerId, string name, string description)
        {
            this.PowerId = PowerId;
            Name = name;
            Description = description;
        }
    }
}
