using DocumentCore.Documents;

namespace DocumentArchiver
{
  public interface IArchiver
  {
    Archive Compress(Document document, string name);
    Document Decompress(Archive archive);
  }
}
