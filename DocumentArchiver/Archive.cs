using DocumentCore.Documents;

namespace DocumentArchiver
{
  public class Archive : SympleDocument
  {
    private Document document;

    public static Archive Compress(Document document, string name)
    {
      return new Archive(document, name);
    }

    public static Document Decompress(Archive archive)
    {
      if (archive is null)
        throw new ArgumentNullException();

      return archive.document;
    }

    private Archive(Document document, string name) : base(name)
    {
      this.document = document;
    }
  }
}
