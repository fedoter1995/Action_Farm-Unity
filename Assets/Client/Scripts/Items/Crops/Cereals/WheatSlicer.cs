using System.Collections.Generic;
using UnityEngine;

namespace CustomTools
{
    public class WheatSlicer : CustomSlicer
    {
        public override void Slice()
        {
            slicedParts = Slicer.Slice(_gameObjectToSlice, transform, _meshRendererToSlice.material);
            for(var i = 0; i<2; i++)
            {
                slicedParts[i].transform.SetParent(_gameObjectToSlice.transform);
                slicedParts[i].transform.position = _gameObjectToSlice.transform.position;
            }
            slicedParts[0].AddComponent<Rigidbody>();
            slicedParts[0].AddComponent<MeshCollider>().convex = true;

        }


    }
}

