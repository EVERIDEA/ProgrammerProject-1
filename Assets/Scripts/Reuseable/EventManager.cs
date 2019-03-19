using System;
using System.Collections.Generic;

public class GameEvent { }

public class EventManager
{
    public delegate void DelegateEvent<T>(T e);
    private static Dictionary<Type, Delegate> delegates = new Dictionary<Type, Delegate>();
    
    public static void AddListener<T>(DelegateEvent<T> del) where T : GameEvent
    {
        Delegate tempDelegate;
        if (delegates.TryGetValue(typeof(T), out tempDelegate))
        {
            DelegateEvent<T> method = tempDelegate as DelegateEvent<T>;
            delegates[typeof(T)] = method += del;
        }
        else
            delegates[typeof(T)] = del;
    }
    public static void TriggerEvent<T>(T evt)
    {
        Delegate tempDelegate;
        if (delegates.TryGetValue(typeof(T), out tempDelegate))
        {
            DelegateEvent<T> del = tempDelegate as DelegateEvent<T>;
            del(evt);
        }
    }
    public static void RemoveListener<T>(DelegateEvent<T> del) where T : GameEvent
    {
        Delegate tempDelegate;
        if (delegates.TryGetValue(typeof(T), out tempDelegate))
        {
            DelegateEvent<T> method = tempDelegate as DelegateEvent<T>;
            method -= del;

            if (method != null)
                delegates[typeof(T)] = method;
            else
                delegates.Remove(typeof(T));
        }
    }

    public static void RemoveAllListeners()
    {
        delegates.Clear();
    }
}
