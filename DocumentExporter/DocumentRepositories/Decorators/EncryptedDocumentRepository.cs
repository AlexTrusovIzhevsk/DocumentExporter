using System;
using DocumentCore.Documents;
using DocumentEncoder;

namespace DocumentExporter.DocumentRepositories.Decorators
{
  internal class EncryptedDocumentRepository : DocumentRepositoryDecorator
  {
    private readonly string key;
    private readonly IEncoder encoder;

    public override int AddDocument(Document document)
    {
      var encryptedDocument = encoder.Encode(document, $"encrypted_{document.Name}", key);
      return repository.AddDocument(encryptedDocument);
    }

    public override Document GetDocument(int id)
    {
      var encryptedDocument = repository.GetDocument(id);
      var document = DecryptDocument(encryptedDocument);
      return document;
    }

    public override Document RemoveDocument(int id)
    {
      var encryptedDocument = repository.RemoveDocument(id);
      var document = DecryptDocument(encryptedDocument);
      return document;
    }

    private Document DecryptDocument(Document encryptedDocument)
    {
      var encryption = encryptedDocument as Encryption;
      if (encryption is null)
        throw new ArgumentException($"Document {encryptedDocument.Id} is not encrypted");

      var document = encoder.Decode(encryption, key);
      return document;
    }

    public EncryptedDocumentRepository(IDocumentRepository repository, string key) : base(repository)
    {
      this.key = key;
      this.encoder = EncoderFactory.CreateEncoder();
    }
  }
}
