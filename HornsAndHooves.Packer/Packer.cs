using System;
using System.Collections.Generic;

namespace HornsAndHooves.Packer
{
  public class Packer : IPacker
  {
    // Эмуляция работы архивирования и разархивирования.
    Dictionary<object, object> objects = new Dictionary<object, object>();

    public object Compress(object obj)
    {
      var key = new object();
      objects[key] = obj;
      return key;
    }

    public object Decompress(object key)
    {
      if(objects.TryGetValue(key, out var value))
        return value;

      throw new ArgumentException();
    }
  }
}