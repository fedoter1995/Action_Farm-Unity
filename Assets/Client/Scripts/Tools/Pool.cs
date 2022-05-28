using System;
using System.Collections.Generic;
using UnityEngine;

namespace CustomTools
{
    public class Pool<T> where T : MonoBehaviour
    {
        public T prefab { get; }
        public bool autoExpand { get; set; }
        public Transform poolsParent { get; }
        private Queue<T> pool = new Queue<T>();
        public Pool(T prefab, int count, Transform poolsParent, bool autoExpand)
        {
            this.prefab = prefab;
            this.poolsParent = poolsParent;
            this.autoExpand = autoExpand;

            this.Init(count);
        }
        public Pool(T prefab, int count, RectTransform poolsParent, bool autoExpand)
        {
            this.prefab = prefab;
            this.poolsParent = poolsParent;
            this.autoExpand = autoExpand;

            this.Init(count);
        }
        //Initialize pool with size = count;
        private void Init(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var obj = CreateObject(poolsParent.position);
            }
        }
        //Create and adding an object to the queue;
        private T CreateObject(Vector3 position, bool activity = false)
        {
            var obj = UnityEngine.Object.Instantiate(prefab, poolsParent);
            obj.transform.localPosition = position;
            obj.gameObject.SetActive(activity);

            pool.Enqueue(obj);

            return obj;
        }
        private bool FindFreeObj(out T _object, Vector3 position)
        {
            foreach(var obj in pool)
            {
                if (!obj.gameObject.activeInHierarchy)
                {
                    _object = obj;
                    obj.transform.position = position;
                    obj.gameObject.SetActive(true);
                    return true;
                }
            }

            _object = null;
            return false;
        }
        public T GetFreeObject()
        {
            if (FindFreeObj(out var _object, Vector3.zero))
                return _object;

            //If auto expansion of elements was supposed
            if (autoExpand)
            {
                return CreateObject(Vector3.zero, true);
            }

            throw new Exception($"No free objects in pool of type {typeof(T)}");
        }
        public void Clear()
        {
            var count = pool.Count;
            for (var i = 0; i < count; i++)
            {
                GameObject.Destroy(pool.Dequeue().gameObject);
            }

        }
    }
}

