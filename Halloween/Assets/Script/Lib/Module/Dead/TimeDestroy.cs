using System.Collections;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
    public float deadTime = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DestroyTimer(deadTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //[SerializeField] float DESTIME = 7f;

    //public void StartDestroyTimer(float time)
    //{
    //   StartCoroutine(DestroyTimer(time));
    //}

    IEnumerator DestroyTimer(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
