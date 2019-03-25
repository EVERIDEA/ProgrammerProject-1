using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using UnityEngine.SceneManagement;

public class BaseApplication<M, V, C> : BaseApplication
    where M : Element
    where V : Element
    where C : Element
{
    new public M model { get { return (M)(object)base.model; } }
    new public V view { get { return (V)(object)base.view; } }
    new public C controller { get { return (C)(object)base.controller; } }
}

public class BaseApplication : Element
{   
    public Model model { get { return m_model = Assert<Model>(m_model); } }
    private Model m_model;
    
    public View view { get { return m_view = Assert<View>(m_view); } }
    private View m_view;
    
    public Controller controller { get { return m_controller = Assert<Controller>(m_controller); } }
    private Controller m_controller;

    private void Start()
    {
        Notify("scene.start");
    }

    public void Notify(string p_event, Object p_target, params object[] p_data)
    {                        
        Log(p_event + " [" + p_target + "]", 6);
        Traverse(delegate(Transform it) {
            Controller[] list = it.GetComponents<Controller>();
            for (int i = 0; i < list.Length; i++) list[i].OnNotification(p_event, p_target, p_data);
            return true;
        });
    }

    public void Notify(string p_event, Object p_target) => Notify(p_event, p_target,new object[]{}); 
    
    public void Notify(float p_delay,string p_event, Object p_target,params object[] p_data) => StartCoroutine(TimedNotify(p_delay,p_event,p_target,p_data));
    
    private IEnumerator TimedNotify(float p_delay, string p_event, Object p_target,params object[] p_data)
    {
        yield return new WaitForSeconds(p_delay);
        Notify(p_event, p_target, p_data);
    }
}