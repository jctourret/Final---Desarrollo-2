using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
namespace TankGame
{
    public static class SaveSystem
    {
        public static void SaveHighschores(HighscoresData data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/highscores.fun";
            FileStream stream = new FileStream(path, FileMode.Create);



            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static HighscoresData LoadHighscores()
        {
            string path = Application.persistentDataPath + "/highscores.fun";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                HighscoresData data = formatter.Deserialize(stream) as HighscoresData;
                stream.Close();

                return data;
            }
            else
            {
                Debug.LogError("Save file not found in" + path);
                return null;
            }
        }
    }
}