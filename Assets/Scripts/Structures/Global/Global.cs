using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using thelab.mvc;
using System.Linq;

public static class Global {

    public static T[] GetInterfaces<T>(this GameObject p_gameObject)
    {
        if (!typeof(T).IsInterface) throw new System.SystemException("Specified type is not an interface!");


        var mObjs = p_gameObject.GetComponentsInChildren<T>();

        return (from a in mObjs where a.GetType().GetInterfaces().Any(k => k == typeof(T)) select (T)(object)a).ToArray();
    }
}
