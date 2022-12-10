using DocumentCore.Documents;

namespace DocumentExporter.DocumentRepositories
{
  public interface IDocumentRepository
  {
    Document GetDocument(int id);
    int AddDocument(Document document);
    Document RemoveDocument(int id);
  }
}
