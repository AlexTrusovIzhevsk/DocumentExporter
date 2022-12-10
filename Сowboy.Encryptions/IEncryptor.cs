namespace Cowboy.Encryptions
{
  // Методы интерфейс должен работать с потоками, но долго замарачиватся, поэтому объекты.
  public interface IEncryptor
  {
    object Encrypt(object obj, string password);
    object Decrypt(object obj, string password);
  }
}
