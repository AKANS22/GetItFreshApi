using System.ComponentModel.DataAnnotations;

namespace GetItFreshApi.Entities
{
    public class BaseType : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
