using System;
using UnityEngine;

public class LineRenderModule : MonoBehaviour
{
    public Transform start;
    public Transform[] targets;
    public GameObject lineRenderer;

    LineRenderer lineObj;

    bool isTimer = false;
    float offTiming = 0;
    float timer = 0;

    void Start()
    {
        lineObj = Instantiate(lineRenderer.gameObject, transform.position, Quaternion.identity).GetComponent<LineRenderer>();
        lineObj.GetComponent<LineRenderer>().enabled = false;
    }

    void Update()
    {
        if (!isTimer) return;

        timer += Time.deltaTime;

        if(timer>=offTiming)
        {
            lineObj.enabled = false;
            isTimer = false;
        }
    }

    public void SetOffTimer(float t)
    {
        isTimer = true;
        offTiming = t;
    }

    public void LineDraw()
    {
        lineObj.enabled = true;

        Vector3[] arrayPos = new Vector3[targets.Length];
        int i = 0;
        foreach (var t in targets)
        {
            arrayPos[i++] = t.position;
        }


        lineObj.positionCount = targets.Length;
        lineObj.SetPositions(arrayPos);

    }
}
