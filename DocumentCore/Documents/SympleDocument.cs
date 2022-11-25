using System.Reflection.Metadata;
using DocumentCore.DescriptionBuilders;

namespace DocumentCore.Documents
{
  public class SympleDocument : Document
  {
    public override void BuildDescription(IDocumentDescriptionBuilder builder)
    {
      using (var depthLevel = new DepthLevel(builder, this));
    }

    public SympleDocument(string name) : base(name)
    {

    }
  }
}
