using DocumentCore.Documents;

namespace DocumentEncoder
{
  public class Encryption : SympleDocument
  {
    private Document document;
    private string key;

    public static Encryption Encrypt(Document document, string name, string key)
    {
      return new Encryption(document, name, key);
    }

    public static Document Decrypt(Encryption encryption, string key)
    {
      if (encryption is null)
        throw new ArgumentNullException();
      if (encryption.key != key)
        throw new ArgumentException(nameof(key));

      return encryption.document;
    }

    private Encryption(Document document, string name, string key) : base(name)
    {
      this.document = document;
      this.key = key;
    }
  }
}