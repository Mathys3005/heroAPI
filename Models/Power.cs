namespace heroAPI.Models
{
    public class Power
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int PowerId { get; set; }
        public virtual ICollection<HeroPower>? HeroPowers { get; set; }
        public Power() { }
    }
}
