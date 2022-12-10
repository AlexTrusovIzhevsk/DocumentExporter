namespace HornsAndHooves.Packer
{
  // Методы интерфейс должен работать с потоками, но долго замарачиватся, поэтому объекты.
  public interface IPacker
  {
    object Compress(object obj);
    object Decompress(object obj);
  }
}
