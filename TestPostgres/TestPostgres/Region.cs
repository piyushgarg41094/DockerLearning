using System.ComponentModel.DataAnnotations;

namespace TestPostgres
{
    public class Region
    {
        public Region()
        {
            School = new HashSet<School>();
        }
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public virtual ICollection<School> School { get; set; }
    }
}
