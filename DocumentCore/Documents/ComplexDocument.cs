using System.Collections.Generic;
using DocumentCore.DescriptionBuilders;

namespace DocumentCore.Documents
{
  public class ComplexDocument : Document
  {
    private List<Document> documents;

    public override void BuildDescription(IDocumentDescriptionBuilder builder)
    {
      using (var depthLevel = new DepthLevel(builder, this))
        foreach (var document in documents)
          document.BuildDescription(builder);
    }

    public ComplexDocument AddDocument(Document document)
    {
      this.documents.Add(document);
      return this;
    }

    public ComplexDocument(string name) : base(name)
    {
      this.documents = new List<Document>();
    }
  }
}
