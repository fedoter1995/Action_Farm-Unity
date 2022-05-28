using EzySlice;
using System.Collections.Generic;
using UnityEngine;

namespace CustomTools
{
    public static class Slicer
    {

        public static GameObject[] Slice(GameObject objectToSlice, Transform slicer, Material material)
        {
            
            return objectToSlice.SliceInstantiate(slicer.position, slicer.up, material);
        }
        /*private  Dictionary<string, GameObject> RecreatingParts(SlicedHull slicedHull, GameObject objectToSlice, Material material)
        {
            var cutParts = new Dictionary<string, GameObject>();

            cutParts.Add("UpperPart", slicedHull.CreateUpperHull(objectToSlice, material));

            cutParts.Add("LowerPart", slicedHull.CreateLowerHull(objectToSlice, material));

            objectToSlice.SetActive(false);

            return cutParts;
        }*/
    }
}
