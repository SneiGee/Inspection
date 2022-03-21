using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Inspection
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string Comments { get; set; } = string.Empty;
        public InspectionType? InspectionType { get; set; }
        public int InspectionTypeId { get; set; }
    }
}