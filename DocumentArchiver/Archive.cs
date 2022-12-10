using DocumentCore.Documents;

namespace DocumentArchiver
{
  public class Archive : SimpleDocument
  {
    internal readonly object Key;

    internal Archive(string name, object key) : base(name)
    {
      this.Key = key;
    }
  }
}
