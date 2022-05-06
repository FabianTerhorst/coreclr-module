using AltV.Net.Client.Elements.Interfaces;

namespace AltV.Net.Client.Elements.Pools
{
    public class RmlDocumentPool : BaseObjectPool<IRmlDocument>
    {
        public RmlDocumentPool(IBaseObjectFactory<IRmlDocument> rmlDocumentPool) : base(rmlDocumentPool)
        {
        }
    }
}