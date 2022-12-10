using DocumentCore.Documents;

namespace DocumentEncoder
{
  public class Encryption : SimpleDocument
  {
    internal readonly object Key;

    internal Encryption(string name, object key) : base(name)
    {
      this.Key = key;
    }
  }
}