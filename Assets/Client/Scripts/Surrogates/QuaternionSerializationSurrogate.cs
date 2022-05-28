using System.Runtime.Serialization;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionSerializationSurrogate : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        var q = (Quaternion)obj;
        info.AddValue("X", q.x);
        info.AddValue("Y", q.y);
        info.AddValue("Z", q.z);
        info.AddValue("W", q.w);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        var q = (Quaternion)obj;
        q.x = (float)info.GetValue("X", typeof(float));
        q.y = (float)info.GetValue("Y", typeof(float));
        q.z = (float)info.GetValue("Z", typeof(float));
        q.w = (float)info.GetValue("W", typeof(float));
        obj = q;
        return obj;
    }
}
