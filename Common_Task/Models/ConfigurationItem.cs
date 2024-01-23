using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common_Task.Models
{
    public class ConfigurationItem
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public ConfigurationItem Parent { get; set; }
        public List<ConfigurationItem> Children { get; set; }
    }
}
