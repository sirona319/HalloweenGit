using UnityEngine;

public class FallPumpkinChild : StraightPointMove
{
    public override void Initialize()
    {
        //base.Initialize();
        direction = (moveTransLists[targetNo].position - transform.position).normalized;

        //transform.rotation = Quaternion.FromToRotation(Vector3.up, direction); //回転180　2LVから　ミスコード
    }
    public override void MoveEnter()
    {
        base.MoveEnter();
        GetComponent<RotModule>().enabled = true;
    }

    public override void MoveExit()
    {
        //base.MoveEnter();
        GetComponent<RotModule>().enabled = false;
        GetComponent<PumpkinBossChildScr>().isFallEnd = true;
    }

    public override void MoveUpdate()
    {



                //指定ポイント方向へ進み続ける（停止しない）
        transform.position += direction * speed * Time.deltaTime;
        //rb2.MovePosition(rb2.position + direction * speed * Time.deltaTime);


        float len = Vector3.Distance(transform.position, moveTransLists[targetNo].position);

        if (len > ENDMOVELEN)
            return;


        //if (len < ENDMOVELEN)
        //{

            //最後の移動地点へ到着したら
            if (targetNo == moveTransLists.Count - 1)
            GetComponent<PumpkinBossChildScr>().isFallMove = false;
        else
            {
                targetNo++;
                direction = (moveTransLists[targetNo].position - transform.position).normalized;
            }

    }
}
