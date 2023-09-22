using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Helper
{
    public class FileHelper
    {
        public enum FILESRC
        {
            DataPath,
            PersistentData
        }
        /*
         * 将json文件读成字符串
         * dictionary文件相对路径
         * fileName文件名
         * src文件所在位置(枚举)
         */
        public static string ReadFileToJson(string directory, string fileName, FILESRC src)
        {
            string jsonStr = "";
            string path= "";
            switch (src)
            {
                case FILESRC.DataPath:
                    path = Application.dataPath;
                    break;
                case FILESRC.PersistentData:
                    path = Application.persistentDataPath;
                    break;
            }

            path = path + directory;
            if(!Directory.Exists(path))
            {
                Debug.LogError("路径不存在");
                return jsonStr;
            }
            path = path + fileName;
            if(!File.Exists(path))
            {
                Debug.LogError("文件不存在");
                return jsonStr;
            }
            jsonStr = File.ReadAllText(path);
            return jsonStr;
        }

        public T JsonStrToObj<T>(string jsonStr)
        {
            T t = JsonUtility.FromJson<T>(jsonStr);
            return default(T);
        }

        public bool SaveObjToJsonFile<T>(string directory, string fileName, T t)
        {
            bool ret = true;
            string path = Application.persistentDataPath + directory;

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!File.Exists(path + fileName))
                {
                    File.CreateText(path + fileName);
                }
                StreamWriter sw = new StreamWriter(path + fileName, false);
                string conStr = JsonUtility.ToJson(t, true);
                sw.WriteLine(conStr);
                sw.Close();
            }
            catch (System.Exception ex)
            {
                ret = false;
                Debug.LogError(ex.Message);
                return ret;
            }
           
            return ret;
        }
    }
}

