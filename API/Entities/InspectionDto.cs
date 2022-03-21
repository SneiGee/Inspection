using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class InspectionDto
    {
        [StringLength(20)]
        public string Status { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string Comments { get; set; } = string.Empty;
        public int InspectionTypeId { get; set; }
    }
}