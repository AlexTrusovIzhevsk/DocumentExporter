using DocumentCore.Documents;
using HornsAndHooves.Packer;

namespace DocumentArchiver
{
  internal class Archiver : IArchiver
  {
    private IPacker packer;

    public Archive Compress(Document document, string name)
    {
      var key = this.packer.Compress(document);
      return new Archive(name, key);
    }

    public Document Decompress(Archive archive)
    {
      var document = packer.Decompress(archive.Key);
      return (Document)document;
    }

    internal Archiver(IPacker packer)
    {
      this.packer = packer;
    }
  }
}