﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreRotation : MonoBehaviour
{

    //Vector3 def;
    //// Start is called before the first frame update
    //void Awake()
    //{
    //    def = transform.localRotation.eulerAngles;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //var te = transform.eulerAngles;
    //    //gameObject.transform.rotation = Quaternion.Euler(te.x, te.y, te.z);

    //    ///////////////
    //    //Vector3 _parent = transform.parent.transform.localRotation.eulerAngles;

    //    ////修正箇所
    //    //transform.localRotation = Quaternion.Euler(def - _parent);

    //    ////ログ用
    //    //Vector3 result = transform.localRotation.eulerAngles;
    //    //Debug.Log("def=" + def + "     _parent=" + _parent + "     result=" + result);
    //}


    //https://teratail.com/questions/31074

    //親回転の相殺

    Quaternion m_DefaultRotation;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Start");
        m_DefaultRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Inverse(transform.parent.rotation) * m_DefaultRotation;
    }
}
