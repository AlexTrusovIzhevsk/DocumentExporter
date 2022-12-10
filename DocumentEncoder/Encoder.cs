using Cowboy.Encryptions;
using DocumentCore.Documents;

namespace DocumentEncoder
{
  public class Encoder : IEncoder
  {
    private readonly IEncryptor encryptor;

    public Encryption Encode(Document document, string name, string password)
    {
      var key = encryptor.Encrypt(document, password);
      return new Encryption(name, key);
    }

    public Document Decode(Encryption encryption, string password)
    {
      var document = encryptor.Decrypt(encryption.Key, password);
      return (Document)document;
    }

    internal Encoder(IEncryptor encryptor)
    {
      this.encryptor = encryptor;
    }
  }
}