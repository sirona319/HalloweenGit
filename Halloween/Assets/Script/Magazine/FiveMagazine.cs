﻿using UnityEngine;

public class FiveMagazine : BaseMagazine, ITarget
{
    public Transform Target { get; set; }
    const float ONEWEYLENGTH = 15f;
    const float TWOWEYLENGTH = 30f;

    CreateBullet createBullet;
    //逆回り作る
    public override void Initialize()
    {
        createBullet = GetComponent<CreateBullet>();
    }

    public override void MagazineEnter()
    {
        //if (targetTrans == null) return;
        FiveShot();
    }
    public override void MagazineUpdate()
    {

    }

    void FiveShot()
    {

        Vector2 direction = Target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        createBullet.BulletAtk(angle + 0, transform.position, transform.rotation);
        createBullet.BulletAtk(angle + ONEWEYLENGTH, transform.position, transform.rotation);
        createBullet.BulletAtk(angle + TWOWEYLENGTH, transform.position, transform.rotation);
        createBullet.BulletAtk(angle + -ONEWEYLENGTH, transform.position, transform.rotation);
        createBullet.BulletAtk(angle + -TWOWEYLENGTH, transform.position, transform.rotation);
    

        //AngleShot(playerAngle, 0);

        //AngleShot(playerAngle,ONEWEYLENGTH);
        //AngleShot(playerAngle,TWOWEYLENGTH);
        //AngleShot(playerAngle,-ONEWEYLENGTH);
        //AngleShot(playerAngle,-TWOWEYLENGTH);

    }

}
