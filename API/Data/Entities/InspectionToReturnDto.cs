namespace API.Data.Entities
{
    public class InspectionToReturnDto
    {
        public string Status { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public int InspectionTypeId { get; set; }
    }
}