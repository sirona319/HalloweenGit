using System;
using UnityEngine;

public class LineRenderModule : MonoBehaviour
{
    //public Transform start;
    public Transform[] targets;
    public GameObject lineRenderer;
    public Material mat;

    LineRenderer lineObj;

    bool isTimer = false;
    float offTiming = 0;
    float timer = 0;

    void Start()
    {
        //lineObj = Instantiate(lineRenderer.gameObject, transform.position, Quaternion.identity).GetComponent<LineRenderer>();
        //lineObj.GetComponent<LineRenderer>().enabled = false;
    }

    void Update()
    {
        if (!isTimer) return;

        timer += Time.deltaTime;

        if(timer>=offTiming)
        {
            lineObj.enabled = false;
            isTimer = false;
            //transform.gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

    public void SetOffTimer(float t)
    {
        isTimer = true;
        offTiming = t;
    }

    public void LineCreate(Transform t)
    {
        lineObj = Instantiate(lineRenderer.gameObject, transform.position, Quaternion.identity, t).GetComponent<LineRenderer>();
        lineObj.enabled = false;
        if (mat == null) return;
            lineObj.material = mat;
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

    //private void OnDestroy()
    //{
    //    Destroy(gameObject);
    //}
}
