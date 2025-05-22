using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace L9_Game3231
{
    public class FileUtil<T>
    {
        public static T DeSerializable(byte[] buff)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            BinaryWriter bw = new BinaryWriter(ms);
            bw.Write(buff);
            ms.Position = 0;
            return (T)bf.Deserialize(ms);
        }
        public static byte[] ToSerializabie(T obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }
}
