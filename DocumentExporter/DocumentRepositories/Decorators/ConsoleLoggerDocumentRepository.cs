using System;
using DocumentCore.DescriptionBuilders;
using DocumentCore.Documents;

namespace DocumentExporter.DocumentRepositories.Decorators
{
  public class ConsoleLoggerDocumentRepository : DocumentRepositoryDecorator
  {
    private IDocumentDescriptionBuilder builder;

    public override int AddDocument(Document document)
    {
      var documentId = repository.AddDocument(document);
      Console.WriteLine($"Добавлен документа. Id:{document.Id}, Name:{document.Name}");
      Console.WriteLine($"Описание:\n{GetDocumentDescription(document)}");
      return documentId;
    }

    public override Document GetDocument(int id)
    {
      var document = repository.GetDocument(id);
      Console.WriteLine($"Получен документ. Id:{document.Id}, Name:{document.Name}");
      Console.WriteLine($"Описание:\n{GetDocumentDescription(document)}");
      return document;
    }

    public override Document RemoveDocument(int id)
    {
      var document = repository.RemoveDocument(id);
      Console.WriteLine($"Удален документа. Id:{document.Id}, Name:{document.Name}");
      Console.WriteLine($"Описание:\n{GetDocumentDescription(document)}");
      return document;
    }

    private string GetDocumentDescription(Document document)
    {
      document.BuildDescription(builder);
      var description = builder.GetResult();
      builder.Clear();
      return description;
    }

    public ConsoleLoggerDocumentRepository(IDocumentRepository repository, IDocumentDescriptionBuilder builder) : base(repository)
    {
      this.builder = builder;
    }
  }
}
