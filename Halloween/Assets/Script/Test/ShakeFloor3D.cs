using UnityEngine;

//床を落とすやつ
public class ShakeFloor3D : MonoBehaviour
{
    bool isFall = false;

    Vector3 returnPos = Vector3.zero;

    [SerializeField] float fallSpeed = 0.1f;

    [SerializeField] float fallPoint = -8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFall)
        {
            var pos = transform.position;
            pos.y -= fallSpeed;
            transform.position = pos;
        }
         

        if (transform.position.y < fallPoint)
        {
            isFall = false;
            transform.position = returnPos;
        }
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isFall) return;
        //if (isShake)
        //    return;
        //isShake = true;
        returnPos = transform.position;

        #region カメラシェイク
        //https://baba-s.hatenablog.com/entry/2018/03/14/170400

        const float SHAKETIME = 1f;
        const float POW = 0.1f;
        StartCoroutine(MyLib.DoShake(SHAKETIME, POW, transform));

        StartCoroutine(MyLib.DelayCoroutine(SHAKETIME, () =>
        {
            GetComponent<Rigidbody>().useGravity = true;
            isFall = true;
            //m_animator.SetBool("Jump", false);
            //m_animator.SetBool("Fall", true);

        }));
        #endregion
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isFall) return;
        //if (isShake)
        //    return;
        //isShake = true;
        returnPos = transform.position;

        #region カメラシェイク
        //https://baba-s.hatenablog.com/entry/2018/03/14/170400

        const float SHAKETIME = 1f;
        const float POW = 0.1f;
        StartCoroutine(MyLib.DoShake(SHAKETIME, POW, transform));

        StartCoroutine(MyLib.DelayCoroutine(SHAKETIME, () =>
        {
            if(GetComponent<Rigidbody>()!=null)
            GetComponent<Rigidbody>().useGravity = true;

            isFall = true;
            //m_animator.SetBool("Jump", false);
            //m_animator.SetBool("Fall", true);

        }));
        #endregion
    }
}
