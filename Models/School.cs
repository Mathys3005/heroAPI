namespace heroAPI.Models
{
    public class School
    {
        public string Name { get; set; }
        public int SchoolId { get; set; }

        public virtual ICollection<Hero> Students { get; set; }

        public School()
        {
        }

        public School(int SchoolId, string name, string address)
        {
            this.SchoolId = SchoolId;
            Name = name;
        }
    }
}
