namespace DocumentCore
{
  public class IdCreater
  {
    public static IdCreater Instance => instance.Value;

    private static readonly Lazy<IdCreater> instance = new Lazy<IdCreater>(() => new IdCreater());
    private static int currentId = 0;
    private static object locker = new object();

    public int NewId()
    {
      lock (locker)
        return currentId++;
    }

    private IdCreater() { }
  }
}
