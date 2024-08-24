namespace heroAPI.Models
{
    public class Hero
    {
        //Properties Name and Power
        public string Name { get; set; }
        public string Power { get; set; }
        public int HeroId { get; set; }

        public virtual ICollection<Power> Powers { get; set; }

        public int SchoolId { get; set; }
        public virtual School School { get; set; }

        public Hero()
        {
        }

        public Hero(int HeroId, string name, string power)
        {
            this.HeroId = HeroId;
            Name = name;
            Power = power;
        }
    }
}
