using UnityEngine;

public class PointMoveFly : PointMove
{
    //ポイント移動を終了するタイミング 攻撃タイミング
    [SerializeField] float atkTimeMax = 6f;
    float atkTime = 0f;

    [SerializeField] float atkLenge = 5;

    public override void MoveEnter()
    {
        base.MoveEnter();
        atkTime = atkTimeMax;
    }

    // Update is called once per frame
    public override void MoveUpdate()
    {
        base.MoveUpdate();

        atkTime -= Time.deltaTime;

        if (atkTime > 0) return;
        if (GameObject.FindGameObjectWithTag(TagName.Player) == null)
        {
            Debug.Log("プレイヤーが存在しない");
            return;
        }


        Atk();
    
    }

    void Atk()
    {
        float targetLen = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag(TagName.Player).transform.position);
        //対象が離れていたら無し
        if (targetLen <= atkLenge)
        {
            GetComponent<FlyScr>().SetAttack();
            Debug.Log("攻撃" + gameObject.name);
        }
        else
        {
            Debug.Log("範囲外" + gameObject.name);

        }

        atkTime = atkTimeMax;
    }
}
