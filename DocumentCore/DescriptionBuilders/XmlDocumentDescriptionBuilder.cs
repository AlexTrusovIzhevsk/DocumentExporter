using System.Text;
using DocumentCore.Documents;

namespace DocumentCore.DescriptionBuilders
{
  public class XmlDocumentDescriptionBuilder : IDocumentDescriptionBuilder
  {
    private const int IndentStep = 2;

    private StringBuilder stringBuilder;
    private int indent;

    public void StartApendDocument(Document document)
    {
      indent += IndentStep;

      this.stringBuilder
        .Append(new string(' ', indent))
        .AppendLine($"<Document name=\"{document.Name}\">");

      indent += IndentStep;

      this.stringBuilder
        .Append(new string(' ', indent))
        .AppendLine($"<Nodes>");
    }

    public void EndAppendDocument()
    {
      this.stringBuilder
        .Append(new string(' ', indent))
        .AppendLine("</Nodes>");

      indent -= IndentStep;

      this.stringBuilder
        .Append(new string(' ', indent))
        .AppendLine("</Document>");

      indent -= IndentStep;
    }

    public string GetResult()
    {
      return this.stringBuilder
        .Append("</DocumentDescription>")
        .ToString();
    }

    public void Clear()
    {
      this.stringBuilder.Clear();
      this.StartBuild();
    }

    private void StartBuild()
    {
      this.stringBuilder.AppendLine("<DocumentDescription>");
      indent = 0;
    }

    public XmlDocumentDescriptionBuilder()
    {
      this.stringBuilder = new StringBuilder();
      this.StartBuild();
    }
  }
}
