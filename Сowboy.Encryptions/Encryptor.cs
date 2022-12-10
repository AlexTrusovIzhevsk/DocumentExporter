using System;
using System.Collections.Generic;

namespace Cowboy.Encryptions
{
  public class Encryptor : IEncryptor
  {
    // Эмуляция работы шифрования и расшифрования.
    Dictionary<object, object> objects = new Dictionary<object, object>();
    Dictionary<object, string> passwords = new Dictionary<object, string>();

    public object Encrypt(object obj, string password)
    {
      var key = new object();
      objects[key] = obj;
      passwords[key] = password;
      return key;
    }

    public object Decrypt(object key, string word)
    {
      if(objects.TryGetValue(key, out var value) && 
        passwords.TryGetValue(key, out var password) && 
        word == password)
        return value;

      throw new ArgumentException();
    }
  }
}