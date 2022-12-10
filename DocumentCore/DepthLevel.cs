using System;
using DocumentCore.DescriptionBuilders;
using DocumentCore.Documents;

namespace DocumentCore
{
  public class DepthLevel : IDisposable
  {
    private IDocumentDescriptionBuilder builder;

    public void Dispose()
    {
      builder.EndAppendDocument();
    }

    public DepthLevel(IDocumentDescriptionBuilder builder, Document complexDocument)
    {
      this.builder = builder;
      this.builder.StartAppendDocument(complexDocument);
    }
  }
}
