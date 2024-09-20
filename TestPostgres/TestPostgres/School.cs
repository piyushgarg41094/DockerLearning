using System.ComponentModel.DataAnnotations;

namespace TestPostgres
{
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}
