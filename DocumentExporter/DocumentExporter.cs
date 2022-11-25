using DocumentExporter.DocumentRepositories;

namespace DocumentExporterProgram
{
  public class DocumentExporter
  {
    public int Copy(IDocumentRepository repository, int documentId, string destinationPath)
    {
      var document = repository.GetDocument(documentId);
      return document.Id;
      // Здесь должно быть копирование, но его нет тк это заглушка.
    }

    public int Relocate(IDocumentRepository sourceRepository, int documentId, IDocumentRepository destinationRepository)
    {
      var document = sourceRepository.RemoveDocument(documentId);
      return destinationRepository.AddDocument(document);
    }
  }
}
