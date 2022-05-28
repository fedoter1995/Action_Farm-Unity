using System.Runtime.Serialization;
using System.Collections.Generic;
using UnityEngine;

public class Vector3SerializationSurrogate : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        var v3 = (Vector3)obj;
        info.AddValue("X", v3.x);
        info.AddValue("Y", v3.y);
        info.AddValue("Z", v3.z);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        var v3 = (Vector3)obj;
        v3.x = (float)info.GetValue("X", typeof(float));
        v3.y = (float)info.GetValue("Y", typeof(float));
        v3.z= (float)info.GetValue("Z", typeof(float));
        obj = v3;

        return obj;
    }
}
