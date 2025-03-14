using DG.Tweening;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;


//https://gomafrontier.com/unity/1585
public class CameraControl : MonoBehaviour
{
    //Tween tween = null;

    [SerializeField] public bool isEventCamera=false;
    Vector3 eventTargetPos = Vector3.zero;
    float cameraDuration = 1f;

    //[SerializeField] bool is2D = false;
    [SerializeField] float cameraZRange = 6f;
    //[SerializeField] float cameraYPos = 0f;


    [SerializeField] Transform cameraTarget;
    [SerializeField] float cameraSpd = 0.08f;
    [SerializeField] float cameraScope = 0.1f;
    //public GameObject mainCamera;
    //private const float rotate_speed = 2f;

    //private const int ROTATE_BUTTON = 1;
    //private const float ANGLE_LIMIT_UP = 75f;//75
    //private const float ANGLE_LIMIT_DOWN = -75f;//75
#if UNITY_ANDROID
    [SerializeField] private VariableJoystick m_variableJoystickCamera;
#endif

    void Start()
    {
        //mainCamera = Camera.main.gameObject;
        //pTrans = GameObject.FindGameObjectWithTag(TagName.Player).transform.Find();
        //const float camaraPosZ = 10f;
        //var setZ=new Vector3(0,0, camaraPosZ);

        //transform.position = setZ;
    }

    void Update()
    { 
        CameraEventUpdate();
    }

    private void FixedUpdate()
    {

    }

    private void LateUpdate()
    {
        CameraTarget2DUpdate();

    }

    void CameraTarget2DUpdate()
    {
        if (isEventCamera) return;

        if(cameraTarget==null)return;

        //GetComponent<Camera>().orthographicSize = cameraZRange;

        //var target = cameraTarget.position;

        //const float camaraPosZ = 10f;
        //target.z = -camaraPosZ;
        //pos.y = cameraYPos;

        //transform.position = target;

        transform.position = Vector3.Lerp(transform.position, cameraTarget.transform.position, cameraSpd*Time.deltaTime);
        //if (Vector3.Distance(target, transform.position) > cameraScope)
        //{
        //    var dir=target - transform.position;

        //    transform.position += dir.normalized * cameraSpd;
        //}

    }

    
    void CameraEventUpdate()
    {
        if (!isEventCamera) return;
        //transform.position = eventTargetPos;

        if (Vector3.Distance(eventTargetPos, transform.position) < 0.01f)
        {
            //Debug.Log("カメラ移動終了Tween");
            return;
        }


        //tween = 
            transform.DOMove(eventTargetPos, cameraDuration).SetEase(Ease.OutSine);

    }

    public void CameraEventTrigger(Vector3 targetPos,float dur)
    {
        isEventCamera = true;
        eventTargetPos = targetPos;
        cameraDuration = dur;
    }

    public void CameraEventTriggerOff()
    {
        isEventCamera = false;
    }

    //private void OnDisable()
    //{
    //    // Tween破棄
    //    if (DOTween.instance != null)
    //    {
    //        tween?.Kill();
    //    }
    //}
}
