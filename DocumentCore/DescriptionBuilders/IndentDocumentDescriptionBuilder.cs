using System.Text;
using DocumentCore.Documents;

namespace DocumentCore.DescriptionBuilders
{
  public class IndentDocumentDescriptionBuilder : IDocumentDescriptionBuilder
  {
    private const int IndentStep = 2;

    private StringBuilder stringBuilder;
    private int indent;

    public void StartApendDocument(Document document)
    {
      this.stringBuilder
        .Append(new string(' ', indent))
        .AppendLine($"{document.Name}");

      indent += IndentStep;
    }

    public void EndAppendDocument()
    {
      indent -= IndentStep;
    }

    public string GetResult()
    {
      return this.stringBuilder.ToString();
    }

    public void Clear()
    {
      this.stringBuilder.Clear();
      indent = 0;
    }

    public IndentDocumentDescriptionBuilder()
    {
      this.stringBuilder = new StringBuilder();
      indent = 0;
    }
  }
}
