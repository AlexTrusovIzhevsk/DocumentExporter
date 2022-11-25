using DocumentCore.Documents;

namespace DocumentExporter.DocumentRepositories
{
  public class DocumentRepository : IDocumentRepository
  {
    private readonly Dictionary<int, Document> documents;

    public int AddDocument(Document document)
    {
      if (document is null)
        throw new ArgumentNullException(nameof(document));

      if (documents.TryGetValue(document.Id, out Document cacheDocument))
      {
        if (cacheDocument == document)
          return document.Id;
        throw new ArgumentException("ID is occupied by another document.");
      }

      documents.Add(document.Id, document);
      return document.Id;
    }

    public Document GetDocument(int id)
    {
      if (documents.TryGetValue(id, out Document document))
        return document;

      return null;
    }

    public Document RemoveDocument(int id)
    {
      if (documents.TryGetValue(id, out Document document))
      {
        documents.Remove(id);
        return document;
      }

      return null;
    }

    public DocumentRepository()
    {
      documents = new Dictionary<int, Document>();
    }
  }
}
