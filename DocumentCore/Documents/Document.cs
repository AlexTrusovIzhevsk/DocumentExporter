using DocumentCore.DescriptionBuilders;

namespace DocumentCore.Documents
{
  public abstract class Document
  {
    public int Id { get; }
    public string Name { get; }
    public abstract void BuildDescription(IDocumentDescriptionBuilder builder);

    public Document(string name)
    {
      Id = IdCreator.Instance.NewId();
      Name = name;
    }
  }
}
