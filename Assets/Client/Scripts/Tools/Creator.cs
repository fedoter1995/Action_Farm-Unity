using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomTools
{
    public sealed class Creator : MonoBehaviour
    {
        private static Creator instance
        {
            get
            {
                if (m_instance == null)
                {
                    var go = new GameObject("[CREATE MANAGER]");
                    m_instance = go.AddComponent<Creator>();
                    DontDestroyOnLoad(go);
                }

                return m_instance;
            }

        }

        private static Creator m_instance;



        public static GameObject Create(string name)
        {
            return new GameObject(name);
        }
        public static GameObject Create(string name, Vector3 position, Quaternion rotation)
        {
            var go = new GameObject(name);
            go.transform.position = position;
            go.transform.rotation = rotation;
            return go;
        }

        public static GameObject Create(Object original)
        {
            return Instantiate(original) as GameObject;
        }
        public static GameObject Create(Object original, Vector3 position, Quaternion rotation)
        {
            return Instantiate(original, position, rotation) as GameObject;
        }
        public static GameObject Create(Object original, Vector3 position, Quaternion rotation, Transform parent)
        {
            return Instantiate(original, position, rotation, parent) as GameObject;
        }

    }
}

