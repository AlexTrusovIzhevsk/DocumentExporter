using DocumentCore.Documents;

namespace DocumentCore.DescriptionBuilders
{
  public interface IDocumentDescriptionBuilder
  {
    void StartAppendDocument(Document document);
    void EndAppendDocument();
    string GetResult();
    void Clear();
  }
}
