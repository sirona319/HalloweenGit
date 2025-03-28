using UnityEngine;
using UnityEngine.InputSystem;

public class PointMoveVecFly : PointVecMove
{
    //ポイント移動を終了するタイミング
    [SerializeField] float endTimeMax = 6f;
    float endTime = 0f;

    //[SerializeField] float len;

    [SerializeField] float lengeMax = 8;

    Transform pt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pt = GameObject.FindWithTag("Player").transform;
    }

    public override void MoveEnter()
    {
        base.MoveEnter();
        endTime = endTimeMax;
    }

    // Update is called once per frame
    public override void MoveUpdate()
    {
        base.MoveUpdate();

        endTime -= Time.deltaTime;

        if (endTime > 0) return;
        
        var len = Vector2.Distance(pt.position, transform.position);
        //対象が離れていたら無し
        if (len <= lengeMax)
        {
            GetComponent<FlyScr>().SetAttack();
            Debug.Log("攻撃" + gameObject.name);
        }
        else
        {
            Debug.Log("攻撃なし" + gameObject.name);

        }

        endTime = endTimeMax;
        
    
    }
}
