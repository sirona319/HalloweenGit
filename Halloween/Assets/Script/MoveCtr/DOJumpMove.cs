using DG.Tweening;
using UnityEngine;

public class JumpMoveDO : BaseMove
{

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void MoveEnter()
    {
        this.transform.DOJump
            (new Vector3(transform.position.x, transform.position.y, 0f), jumpPower: 1f, numJumps: 1, duration: 1f)
            .SetLoops(-1, LoopType.Yoyo);
        //this.transform.DOJump
        //    (new Vector3(rb2.position.x, rb2.position.y, 0f), jumpPower: 1f, numJumps: 1, duration: 1f)
        //    .SetLoops(-1, LoopType.Yoyo);
    }

    public override void MoveUpdate()
    {

    
    }

}

