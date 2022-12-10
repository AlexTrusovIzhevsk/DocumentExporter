using System;
using DocumentExporter.DocumentRepositories;

namespace DocumentExporter
{
  public class DocumentRepositoryDecorateHelper
  {
    private IDocumentRepository repository;

    public DocumentRepositoryDecorateHelper Decorate(Func<IDocumentRepository, IDocumentRepository> decorate)
    {
      this.repository = decorate(this.repository);
      return this;
    }

    public IDocumentRepository GetResult()
    {
      return repository;
    }

    public DocumentRepositoryDecorateHelper(IDocumentRepository repository)
    {
      this.repository = repository;
    }
  }
}
