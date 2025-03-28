using UnityEngine;

public class PlayerAttackMoveFly : PlayerAttackMove
{
    public override void MoveUpdate()
    {

        base.MoveUpdate();

        if(isAttackEnd)
        {
            GetComponent<FlyScr>().SetMove();

        }

    }
}
