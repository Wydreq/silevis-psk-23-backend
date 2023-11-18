namespace api_v3.Entities
{
    public class BaseModifiableEntity : BaseEntity, IModificableEntity
    {
        public DateTime DtCrt { get; set; }
        public string UsrCrt { get; set; }
        public DateTime? DtChg {  get; set; }
        public string UsrChg { get; set; }

    }
}
