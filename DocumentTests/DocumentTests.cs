using DocumentCore.DescriptionBuilders;
using DocumentCore.Documents;

namespace DocumentTests
{
  public class DocumentTests
  {
    private IDocumentDescriptionBuilder builder;

    [SetUp]
    public void Setup()
    {
      builder = new IndentDocumentDescriptionBuilder();
    }

    [Test]
    public void CreateSympleDocument()
    {
      var documentName = "TestDocument";
      var document = new SympleDocument(documentName);

      document.BuildDescription(builder);
      var description = builder.GetResult();

      Assert.That(document.Name, Is.EqualTo(documentName));
    }

    [Test]
    public void CreateTwoDocumentDifferentId()
    {
      var document0 = new SympleDocument("Document0");
      var document1 = new SympleDocument("Document1");

      Assert.That(document1.Id, Is.Not.EqualTo(document0.Id));
    }
  }
}