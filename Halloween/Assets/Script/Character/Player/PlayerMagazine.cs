using UnityEngine;
using static TargetSet;

public class PlayerMagazine : BaseMagazine
{
    CreateBullet createBullet;

    //TargetSet targetSet;
    [SerializeField] Transform target;

    float intervalTime = 0f;
    [SerializeField] float intervalTimeMax = 1f;


    [SerializeField] GameObject pNormal;
    [SerializeField] GameObject pStraight;

    void Start()
    {
        createBullet = GetComponent<CreateBullet>();
        //targetSet = GetComponent<TargetSet>();

        //target = targetSet.Set();

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

            Shot();

            MyLib.MyPlayOneSound("Sound/SE/wave/刀を鞘にしまう1", 0.1f, gameObject);
        }

        if (Input.GetKey(KeyCode.G) && intervalTime <= 0)
        {
            intervalTime = intervalTimeMax;

            //修正
            Vector2 direction = transform.position-(transform.position+Vector3.right) ;
            float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

            createBullet.BulletAtkNotGravity(pAngle, transform.position, transform.rotation,pStraight); //Target渡す

            MyLib.MyPlayOneSound("Sound/SE/wave/刀を鞘にしまう1", 0.1f, gameObject);
        }
    }

    void Shot()
    {

        Vector2 direction = target.position - transform.position;
        float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        createBullet.BulletAtk(pAngle, transform.position, transform.rotation,pNormal); //Target渡す
    }
}
