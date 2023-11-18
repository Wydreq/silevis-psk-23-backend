namespace api_v3.Entities
{
    public interface IModificableEntity : IEntity
    {
        public DateTime DtCrt { get; set; }
        public string UsrCrt { get; set; }
        public DateTime? DtChg { get; set; }
        public string UsrChg { get; set; }

    }
}
