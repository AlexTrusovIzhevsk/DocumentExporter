using Cowboy.Encryptions;

namespace DocumentEncoder
{
  public static class EncoderFactory
  {
    public static IEncoder CreateEncoder()
    {
      var encryptor = new Encryptor();
      return new Encoder(encryptor);
    }
  }
}
