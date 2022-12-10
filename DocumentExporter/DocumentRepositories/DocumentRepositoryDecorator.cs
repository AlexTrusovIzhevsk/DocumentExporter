using DocumentCore.Documents;

namespace DocumentExporter.DocumentRepositories
{
  public abstract class DocumentRepositoryDecorator : IDocumentRepository
  {
    protected readonly IDocumentRepository repository;

    public virtual int AddDocument(Document document)
    {
      return repository.AddDocument(document);
    }

    public virtual Document GetDocument(int id)
    {
      return repository.GetDocument(id);
    }

    public virtual Document RemoveDocument(int id)
    {
      return repository.RemoveDocument(id);
    }

    public DocumentRepositoryDecorator(IDocumentRepository repository)
    {
      this.repository = repository;
    }
  }
}
