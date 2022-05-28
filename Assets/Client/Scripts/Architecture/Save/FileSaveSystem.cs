using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveSystem
{
    public class FileSaveSystem
    {
        private readonly string savePath;
        private BinaryFormatter formatter;
        public FileSaveSystem()
        {
            var directory = Application.persistentDataPath + "/saves";
            if(!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            savePath = directory + "/Save.save";
            InitBinaryFormatter();
        }

        private void InitBinaryFormatter()
        {
            formatter = new BinaryFormatter();

            var selector = new SurrogateSelector();
            var v3Surrogate = new Vector3SerializationSurrogate();
            var qSurrogate = new QuaternionSerializationSurrogate();

            selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), v3Surrogate);
            selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), qSurrogate);

            formatter.SurrogateSelector = selector;
        }
        public void Save(object saveData)
        {
            var file = File.Create(savePath);
            formatter.Serialize(file, saveData);
            file.Close();
        }

        public object Load(object defaultSaveData)
        {
            if (!File.Exists(savePath))
            {
                if (defaultSaveData != null)
                    Save(defaultSaveData);
                return defaultSaveData;
            }

            var file = File.Open(savePath, FileMode.Open);
            var saveData = formatter.Deserialize(file);
            file.Close();
            return saveData;
        }
    }
}

