using UnityEngine;
using static TargetSet;

public class PlayerMagazine : BaseMagazine
{
    CreateBullet createBullet;

    TargetSet targetSet;
    Transform target;

    [SerializeField] float intervalTime = 0f;
    [SerializeField] float intervalTimeMax = 1f;

    void Start()
    {
        createBullet = GetComponent<CreateBullet>();
        targetSet = GetComponent<TargetSet>();

        target = targetSet.Set(TargetName.Bullet);

        intervalTime = intervalTimeMax;
    }


    public override void MagazineEnter()
    {

    }
    public override void MagazineUpdate()
    {

        intervalTime -= Time.deltaTime;
        if (Input.GetKey(KeyCode.F) && intervalTime <= 0)
        {
            intervalTime = intervalTimeMax;

            NormalShot();

            MyLib.MyPlayOneSound("Sound/SE/wave/刀を鞘にしまう1",0.1f, gameObject);
        }
    }

    void NormalShot()
    {

        Vector2 direction = target.position - transform.position;
        float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        createBullet.BulletAtk(pAngle, transform.position, transform.rotation); //Target渡す
    }
}
