using HornsAndHooves.Packer;

namespace DocumentArchiver
{
  public static class ArchiverFactory
  {
    public static IArchiver CreateArchiver()
    {
      var packer = new Packer();
      return new Archiver(packer);
    }
  }
}
