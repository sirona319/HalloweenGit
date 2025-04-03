using UnityEngine;

public class FallPumpkinChild : StraightPointMove
{
    public override void Initialize()
    {
        base.Initialize();
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

        base.MoveUpdate();

        if(IsMoveEnd.Value)
        {
            GetComponent<PumpkinBossChildScr>().isFallMove = false;
            //GetComponent<PumpkinBossChildScr>().isSpawnMove = true;//&&isAllfall
        }

    }
}
