namespace WELLTRACKSOFT.Models
{
    public class csBillCodesRelations
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string PlacesOfService { get; set; }
        public string Description { get; set; } 
        public int tabBillingCodesTypesRelationId { get; set; }
    }
}
