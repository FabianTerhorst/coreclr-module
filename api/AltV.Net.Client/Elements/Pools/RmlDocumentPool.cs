using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Pools
{
    public class RmlDocumentPool : BaseObjectPool<IRmlDocument>
    {
        public RmlDocumentPool(IBaseObjectFactory<IRmlDocument> rmlDocumentPool) : base(rmlDocumentPool)
        {
        }
    }
}