using System;
using System.Collections;
using UnityEngine;

public abstract class BaseMove : MonoBehaviour
{

    protected Rigidbody m_rb3;

    protected Rigidbody2D m_rb;
    public bool IsMove = true;

    public Vector3 GetPos()
    {
        if (GetComponent<Rigidbody2D>() != null)
            return m_rb.position;

        if (GetComponent<Rigidbody>() != null)
            return m_rb3.position;

        return transform.position;
    }

    public virtual void Initialize()
    {
        if(GetComponent<Rigidbody2D>()!=null)
        m_rb = GetComponent<Rigidbody2D>();

        if (GetComponent<Rigidbody>() != null)
            m_rb3 = GetComponent<Rigidbody>();
    }

    public abstract void MoveEnter();
    //public virtual void MoveExit()
    //{

    //}


    public abstract void MoveUpdate();


    //public IEnumerator ExCoroutine(float seconds, Action action)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    action?.Invoke();
    //}
}
