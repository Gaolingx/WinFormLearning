using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using   LitJson;

namespace Game3231
{
    public class UtilClass<T>
    {
        public static void SaveJson(string fileName, T t)
        {
            StreamWriter streamWriter = new StreamWriter(fileName);
            string str=JsonMapper.ToJson(t);
            streamWriter.Write(str);
            streamWriter.Close();
        }
        public static T ReadJson(string fileName)
        {
            T t=default(T);
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(fileName);
                string str = streamReader.ReadToEnd();
                t = JsonMapper.ToObject<T>(str);
                streamReader.Close();
            }
            catch (Exception ex)
            {

            } finally { if (streamReader != null)
                {
                    try
                    {
                        streamReader.Close();
                    }
                    catch (Exception ex)
                    {
                    
                    }   
                    }
            }
            return t;
        }
        public static void SaveObject(string fileName,T t)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            binaryFormatter.Serialize(fs, t);
            fs.Close();
        }
        public static T ReadObject(string fileName)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(fileName, FileMode.Open);
            T t=(T)binaryFormatter.Deserialize(fs);
            fs.Close();
            return t;
        }


    }
}
