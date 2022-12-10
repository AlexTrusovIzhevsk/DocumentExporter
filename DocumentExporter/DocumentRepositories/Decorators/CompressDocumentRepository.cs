using System;
using DocumentArchiver;
using DocumentCore.Documents;

namespace DocumentExporter.DocumentRepositories.Decorators
{
  internal class CompressDocumentRepository : DocumentRepositoryDecorator
  {
    private IArchiver archiver;

    public override int AddDocument(Document document)
    {
      var archive = archiver.Compress(document, $"compress_{document.Name}");
      return repository.AddDocument(archive);
    }

    public override Document GetDocument(int id)
    {
      var compressedDocument = repository.GetDocument(id);
      var document = DecompressDocument(compressedDocument);
      return document;
    }

    public override Document RemoveDocument(int id)
    {
      var compressedDocument = repository.RemoveDocument(id);
      var document = DecompressDocument(compressedDocument);
      return document;
    }

    private Document DecompressDocument(Document compressedDocument)
    {
      var archive = compressedDocument as Archive;
      if (archive is null)
        throw new ArgumentException($"Document {compressedDocument.Id} is not archive");

      var document = archiver.Decompress(archive);
      return document;
    }

    public CompressDocumentRepository(IDocumentRepository repository) : base(repository)
    {
      this.archiver = ArchiverFactory.CreateArchiver();
    }
  }
}
