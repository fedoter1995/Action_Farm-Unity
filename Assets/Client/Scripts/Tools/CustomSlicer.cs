using System.Collections.Generic;
using UnityEngine;

namespace CustomTools
{
    public abstract class CustomSlicer : MonoBehaviour
    {
        [SerializeField] protected GameObject _gameObjectToSlice;
        [SerializeField] protected MeshRenderer _meshRendererToSlice;

        protected GameObject[] slicedParts;
        public abstract void Slice();
        public void DestroyParts()
        {
            for (var i = 0; i < slicedParts.Length; i++)
                Destroy(slicedParts[i]);
        }

    }
}

