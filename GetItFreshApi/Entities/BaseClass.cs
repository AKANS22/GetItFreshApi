using System.ComponentModel.DataAnnotations;

namespace GetItFreshApi.Entities
{
    public class BaseClass
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
