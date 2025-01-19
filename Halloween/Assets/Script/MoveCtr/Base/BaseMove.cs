using System;
using System.Collections;
using UnityEngine;

public abstract class BaseMove : MonoBehaviour
{


    protected Rigidbody2D m_rb;
    public bool IsMove = true;

    public virtual void Initialize()
    {
        m_rb = GetComponent<Rigidbody2D>();
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
