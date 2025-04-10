using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.Universal;

public class LightCtr2D : MonoBehaviour
{
    [SerializeField] Light2D[] lights2D;

    bool isLight = false;
    //[SerializeField] float targetValSpeed = 0.3f;
    [SerializeField] float targetValMax = 2f;

    float targetVal = 0f;

    [SerializeField] float changeSpeed = 0f;

    float diff = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLight) return;

        foreach (var l in lights2D)
        {
            l.intensity += diff * changeSpeed;
            
            //if (l.intensity < 0.01f)
            //    l.intensity = 0;

            //if(math.distance(lights2D[0].intensity, targetVal) < 0.01f)
            //    l.intensity = targetValMax;


        }

        if(math.distance(lights2D[0].intensity, targetVal)<0.01f)
        {
            foreach (var l in lights2D)
            {
                l.intensity = targetVal;
            }
            isLight = false;

        }


        //if (isLight)
        //{

        //    foreach (var l in lights2D)
        //    {
        //        l.intensity += targetValSpeed;

        //        if (l.intensity > targetValMax)
        //            isLight = false;

        //    }
        //}
        //else
        //{
        //    foreach (var l in lights2D)
        //    {
        //        l.intensity -= targetValSpeed;
        //        if (l.intensity < 0.0f)
        //            break;
        //            //isLight = true;
        //    }
        //}

    }

    public void LightIntentisySet(float val)
    {
        targetVal = val;
        isLight = true;

        var lightVal = lights2D[0].intensity;

        diff = (targetVal- lightVal);


        //float targetValSpeed = 0.3f;

        //StartCoroutine(MyLib.LoopDelayCoroutineIf(lights2D[lights2D.Length-1].intensity>=targetVal, () =>
        //{
        //    foreach (var l in lights2D)
        //    {
        //        l.intensity += targetValSpeed;

        //    }
        //}));


        //l.intensity = val;

        //DOFade(lights2D[0].intensity, 0.0f, 1.0f).OnComplete(() =>
        //{
        //    foreach (var l in lights2D)
        //    {
        //        l.intensity = val;
        //    }
        //});
    }

    public void Test(float val)
    {
        lights2D[0].intensity=100;

    }
}
