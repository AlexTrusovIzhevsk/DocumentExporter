using DocumentCore.Documents;

namespace DocumentEncoder
{
  public interface IEncoder
  {
    Encryption Encode(Document document, string name, string key);
    Document Decode(Encryption encryption, string key);
  }
}