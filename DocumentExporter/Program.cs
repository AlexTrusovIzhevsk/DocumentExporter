using DocumentCore.DescriptionBuilders;
using DocumentCore.Documents;
using DocumentExporter;
using DocumentExporter.DocumentRepositories;
using DocumentExporter.DocumentRepositories.Decorators;

namespace DocumentExporterProgram
{
  public class Program
  {
    public static void Main()
    {
      var sympleDocument = new SympleDocument("SympleDocument");

      var complexDocument = new ComplexDocument("ComplexDocument")
        .AddDocument(new SympleDocument("Document0"))
        .AddDocument(new SympleDocument("Document1"));

      var multilevelСomplexDocument = new ComplexDocument("MultilevelСomplexDocument")
        .AddDocument(new SympleDocument("Document2"))
        .AddDocument(new SympleDocument("Document3"))
        .AddDocument(new ComplexDocument("InnerСomplexDocument")
          .AddDocument(new SympleDocument("Document4"))
          .AddDocument(new SympleDocument("Document5")))
        .AddDocument(new SympleDocument("Document6"));

      // Билдер который формирует описание в формате XML.
      //var builder = new XmlDocumentDescriptionBuilder();

      var builder = new IndentDocumentDescriptionBuilder();

      var sourceRepository = 
        new DocumentRepositoryDecorateHelper(new DocumentRepository())
        .Decorate((repository) => new ConsoleLoggerDocumentRepository(repository, builder))
        .GetResult();

      DoCase("ЗАГРУЗКА ДАННЫХ", () =>
      {
        sourceRepository.AddDocument(sympleDocument);
        sourceRepository.AddDocument(complexDocument);
        sourceRepository.AddDocument(multilevelСomplexDocument);
      });

      var exporter = new DocumentExporter();
      DoCase("ПОЛУЧЕНИЕ ДАННЫХ", () =>
      {
        exporter.Copy(sourceRepository, sympleDocument.Id, @"D:\TEMP");
        exporter.Copy(sourceRepository, complexDocument.Id, @"D:\TEMP");
      });

      DoCase("ПЕРЕНОС ДАННЫХ", () =>
      {
        var destinationRepository = new DocumentRepository();
        exporter.Relocate(sourceRepository, multilevelСomplexDocument.Id, destinationRepository);
        exporter.Relocate(destinationRepository, multilevelСomplexDocument.Id, sourceRepository);
      });

      DoCase("АРХИВАЦИЯ ДАННЫХ", () =>
      {
        var destinationRepository = new DocumentRepositoryDecorateHelper(new DocumentRepository())
          .Decorate((repository) => new ConsoleLoggerDocumentRepository(repository, builder))
          .Decorate((repository) => new CompressDocumentRepository(repository))
          .GetResult();

        var documentId = exporter.Relocate(sourceRepository, complexDocument.Id, destinationRepository);
        exporter.Relocate(destinationRepository, documentId, sourceRepository);
      });

      var key = "qwerty";
      DoCase("ШИФРОВАНИЕ ДАННЫХ", () =>
      {
        var destinationRepository = new DocumentRepositoryDecorateHelper(new DocumentRepository())
          .Decorate((repository) => new ConsoleLoggerDocumentRepository(repository, builder))
          .Decorate((repository) => new EncryptedDocumentRepository(repository, key))
          .GetResult();

        var documentId = exporter.Relocate(sourceRepository, complexDocument.Id, destinationRepository);
        exporter.Relocate(destinationRepository, documentId, sourceRepository);
      });

      DoCase("ШИФРОВАНИЕ И АРХИВАЦИЯ ДАННЫХ", () =>
      {
        var destinationRepository = new DocumentRepositoryDecorateHelper(new DocumentRepository())
          .Decorate((repository) => new ConsoleLoggerDocumentRepository(repository, builder))
          .Decorate((repository) => new CompressDocumentRepository(repository))
          .Decorate((repository) => new EncryptedDocumentRepository(repository, key))
          .GetResult();
        var documentId = exporter.Relocate(sourceRepository, complexDocument.Id, destinationRepository);
        exporter.Relocate(destinationRepository, documentId, sourceRepository);
      });
    }

    private static void DoCase(string caseName, Action caseAction)
    {
      Console.WriteLine(caseName);
      Console.WriteLine(new string('\n', 1));
      caseAction();
      Console.WriteLine(new string('_', 50));
      Console.WriteLine(new string('\n', 3));
    }
  }
}
