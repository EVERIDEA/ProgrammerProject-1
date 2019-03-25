using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Element<T> : Element where T : BaseApplication
{
    new public T app { get { return (T)base.app; } }
}

public class Element : MonoBehaviour {
    public BaseApplication app { get { return m_app = Assert<BaseApplication>(m_app, true); } }
    private BaseApplication m_app;

    private Dictionary<string, object> m_store { get { return _store == null ? (_store = new Dictionary<string, object>()) : _store; } }
    private Dictionary<string, object> _store;

    public T Assert<T>(T p_var, bool p_global=false) where T : Object {
        return p_var == null ? (p_global ? GameObject.FindObjectOfType<T>() : transform.GetComponentInChildren<T>()) : p_var;            
    }
    
    public T Assert<T>(string p_key, bool p_global = false) where T : Object
    {
        if (m_store.ContainsKey(p_key)) { return (T)(object)m_store[p_key]; }
        T v = (p_global ? GameObject.FindObjectOfType<T>() : transform.GetComponentInChildren<T>());
        m_store[p_key] = v;
        return v;
    }

    public T AssertLocal<T>(string p_key) where T : Object
    {
        if (m_store.ContainsKey(p_key)) { return (T)(object)m_store[p_key]; }
        T v = GetComponent<T>();
        m_store[p_key] = v;
        return v;
    }

    public T AssertLocal<T>(T p_var,string p_store="") where T : Object
    {
        T v = default(T);
        if (p_store != "") if (m_store.ContainsKey(p_store)) { return (T)(object)m_store[p_store]; }   
        v = p_var == null ? (p_var = GetComponent<T>()) : p_var;
        if (p_store != "") m_store[p_store] = v;
        return v;
    }

    public T AssertParent<T>(string p_key) where T : Object
    {
        if (m_store.ContainsKey(p_key)) { return (T)(object)m_store[p_key]; }
        T v = GetComponentInParent<T>();
        m_store[p_key] = v;
        return v;
    }
    
    public T AssertParent<T>(T p_var, string p_store = "") where T : Object
    {
        T v = default(T);
        if (p_store != "") if (m_store.ContainsKey(p_store)) { return (T)(object)m_store[p_store]; }
        v = p_var == null ? (p_var = GetComponentInParent<T>()) : p_var;
        if (p_store != "") m_store[p_store] = v;
        return v;
    }
    
    public T AssertCache<T>(string p_store,T p_value)
    {
        if (m_store.ContainsKey(p_store)) { return (T)(object)m_store[p_store]; }
        m_store[p_store] = p_value;
        return p_value;
    }
    
    public T Cast<T>() { return (T)(object)this; }
    
    public T Find<T>(string p_path) where T : Component
    {
        List<string> tks = new List<string>(p_path.Split('.'));
        if (tks.Count <= 0) return default(T);
        Transform it = transform;
        while (tks.Count > 0) {
            string p = tks[0];
            tks.RemoveAt(0);
            it = it.Find(p);
            if (it == null) return default(T);
        }
        return it.GetComponent<T>();
    }
    
    public T AssertFind<T>(string p_path) where T : Component
    {
        if (m_store.ContainsKey(p_path)) { return (T)(object)m_store[p_path]; }
        T v = Find<T>(p_path);
        m_store[p_path] = v;
        return v;
    }
    
    public void Notify(string p_event,params object[] p_data) { app.Notify(p_event, this, p_data); }

    public void Notify(string p_event, object p_data)
    {
        object[] arr = new object [] { p_data };
        app.Notify(p_event, this, p_data);
    }
    
    public void Notify(float p_delay,string p_event,params object[] p_data) { app.Notify(p_delay,p_event, this, p_data); }
    
    public void Traverse(System.Predicate<Transform> p_callback) {
        OnTraverseStep(transform,p_callback);
    }
    
    private void OnTraverseStep(Transform p_target,System.Predicate<Transform> p_callback) {
        if(p_target) if(!p_callback(p_target)) return;
        for(int i=0;i<p_target.childCount;i++) { OnTraverseStep(p_target.GetChild(i),p_callback); }
    }
    
    public void Log(object p_msg, int p_verbose = 0) => Debug.Log(GetType().Name + "> " + p_msg);

}