namespace heroAPI.Models
{
    public class Hero
    {
        //Properties Name and Power
        public string Name { get; set; }
        public int HeroId { get; set; }

        public virtual ICollection<HeroPower>? HeroPowers { get; set; }

        public int? SchoolId { get; set; }
        public virtual School? School { get; set; }

        public Hero() { }
    }
}
