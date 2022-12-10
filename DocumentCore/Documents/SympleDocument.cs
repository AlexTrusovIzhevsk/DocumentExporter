using System.IO;
using DocumentCore.DescriptionBuilders;

namespace DocumentCore.Documents
{
  public class SimpleDocument : Document
  {

    public override void BuildDescription(IDocumentDescriptionBuilder builder)
    {
      using var depthLevel = new DepthLevel(builder, this);
    }

    public SimpleDocument(string name) : base(name) {  }
  }
}
