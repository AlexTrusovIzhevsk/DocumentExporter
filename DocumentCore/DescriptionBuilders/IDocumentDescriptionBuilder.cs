using DocumentCore.Documents;

namespace DocumentCore.DescriptionBuilders
{
  public interface IDocumentDescriptionBuilder
  {
    void StartApendDocument(Document document);
    void EndAppendDocument();
    string GetResult();
    void Clear();
  }
}
