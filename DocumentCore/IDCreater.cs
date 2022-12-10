using System;

namespace DocumentCore
{
  public class IdCreator
  {
    public static IdCreator Instance => instance.Value;

    private static readonly Lazy<IdCreator> instance = new Lazy<IdCreator>(() => new IdCreator());
    private static int currentId = 0;
    private static object locker = new object();

    public int NewId()
    {
      lock (locker)
        return currentId++;
    }

    private IdCreator() { }
  }
}
