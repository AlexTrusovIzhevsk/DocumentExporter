using DocumentArchiver;
using DocumentCore.Documents;

namespace DocumentExporter.DocumentRepositories.Decorators
{
  internal class CompressDocumentRepository : DocumentRepositoryDecorator
  {
    public override int AddDocument(Document document)
    {
      var archive = Archive.Compress(document, $"compress_{document.Name}");
      return repository.AddDocument(archive);
    }

    public override Document GetDocument(int id)
    {
      var compresedDocument = repository.GetDocument(id);
      var document = DecompressDocument(compresedDocument);
      return document;
    }

    public override Document RemoveDocument(int id)
    {
      var compresedDocument = repository.RemoveDocument(id);
      var document = DecompressDocument(compresedDocument);
      return document;
    }

    private Document DecompressDocument(Document compresedDocument)
    {
      var archive = compresedDocument as Archive;
      if (archive is null)
        throw new ArgumentException($"Document {compresedDocument.Id} is not archive");

      var document = Archive.Decompress(archive);
      return document;
    }

    public CompressDocumentRepository(IDocumentRepository repository) : base(repository) { }
  }
}
