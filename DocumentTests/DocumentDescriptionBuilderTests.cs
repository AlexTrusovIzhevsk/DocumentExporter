using DocumentCore.DescriptionBuilders;
using DocumentCore.Documents;
using NUnit.Framework;

namespace DocumentTests
{
  public class DocumentDescriptionBuilderTests
  {
    private Document document;

    [SetUp]
    public void Setup()
    {
      document = new ComplexDocument("Root—omplexDocument")
        .AddDocument(new SimpleDocument("Document0"))
        .AddDocument(new SimpleDocument("Document1"))
        .AddDocument(new ComplexDocument("—omplexDocument")
          .AddDocument(new SimpleDocument("Document2"))
          .AddDocument(new SimpleDocument("Document3")))
        .AddDocument(new SimpleDocument("Document5"));
    }

    [Test]
    public void IndentDocumentDescriptionBuilderTest()
    {
      var builder = new IndentDocumentDescriptionBuilder();
      document.BuildDescription(builder);
      var result = builder.GetResult();

      var description =
        """
        Root—omplexDocument
          Document0
          Document1
          —omplexDocument
            Document2
            Document3
          Document5

        """;

      Assert.That(result, Is.EqualTo(description));
    }

    [Test]
    public void XmlDocumentDescriptionBuilderTest()
    {

      var builder = new XmlDocumentDescriptionBuilder();
      document.BuildDescription(builder);
      var result = builder.GetResult();

      var description =
        """
        <DocumentDescription>
          <Document name="Root—omplexDocument">
            <Nodes>
              <Document name="Document0">
                <Nodes>
                </Nodes>
              </Document>
              <Document name="Document1">
                <Nodes>
                </Nodes>
              </Document>
              <Document name="—omplexDocument">
                <Nodes>
                  <Document name="Document2">
                    <Nodes>
                    </Nodes>
                  </Document>
                  <Document name="Document3">
                    <Nodes>
                    </Nodes>
                  </Document>
                </Nodes>
              </Document>
              <Document name="Document5">
                <Nodes>
                </Nodes>
              </Document>
            </Nodes>
          </Document>
        </DocumentDescription>
        """;

      Assert.That(result, Is.EqualTo(description));
    }
  }
}