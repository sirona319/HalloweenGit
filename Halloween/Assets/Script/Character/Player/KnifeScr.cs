using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KnifeScr : ReleaseDestroyer
{
    [SerializeField] ParticleSystem breakPt;
    private void Start()
    {
        breakPt = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/CFXR Magic Poof");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.CompareTag(TagName.Enemy))
        {
            var iDamage = other.transform.GetComponent<IDamage>();
            if (iDamage != null)
            {
                MyLib.DebugInfo(other.gameObject);
                iDamage.Damage(1);

            }
            else
                Debug.Log("ダメージインターフェイスが無いよ！！" + TagName.Enemy);

            //Debug.Log("攻撃が敵にHIT");
            PoolDestroy();
            return;
        }

        if (other.CompareTag(TagName.EnemyBoss))
        {
            var iDamage = other.GetComponent<IDamage>();
            if (iDamage != null)
                iDamage.Damage(1);
            else
                Debug.Log("ダメージインターフェイスが無いよ！！EnemyBoss" + TagName.EnemyBoss);

            //Debug.Log("攻撃が敵にHITBOSS");
            PoolDestroy();
            return;
        }


    }

    private void OnCollisionEnter2D(Collision2D ot)
    {

        if (ot.gameObject.CompareTag(TagName.GroundBreak))
        {
            //https://qiita.com/kako_vail/items/57c574629fcaf4d9787f
            Debug.Log("KNIFE");
            //変数作って初期化
            Vector3 hitPos = Vector3.zero;
            //あたった場所の座標を取得

            foreach (ContactPoint2D point in ot.contacts)
            {
                hitPos = point.point;
            }

            BoundsInt.PositionEnumerator position = ot.gameObject.GetComponent<Tilemap>().cellBounds.allPositionsWithin;
            var allPosition = new List<Vector3>();
            //一番近い場所を保存したいので変数を宣言
            int minPositionNum = 0;

            foreach (var variable in position)
            {
                if (ot.gameObject.GetComponent<Tilemap>().GetTile(variable) != null)
                {
                    allPosition.Add(variable);
                }
            }


            //for文で探査する。でも初期化で0入れてるから1からスタート
            for (int i = 1; i < allPosition.Count; i++)
            {
                //それぞれのあたった場所からの大きさを取得、最小を更新したらminPositionNumを更新する
                if ((hitPos - allPosition[i]).magnitude < (hitPos - allPosition[minPositionNum]).magnitude)
                {
                    minPositionNum = i;
                }
            }


            //最終的な位置を一旦格納した。RoundToIntは四捨五入とのことです
            Vector3Int finalPosition = Vector3Int.RoundToInt(allPosition[minPositionNum]);


            TileBase tiletmp = ot.gameObject.GetComponent<Tilemap>().GetTile(finalPosition);

            if (tiletmp != null)
            {
                Tilemap map = ot.gameObject.GetComponent<Tilemap>();
                TilemapCollider2D tileCol = ot.gameObject.GetComponent<TilemapCollider2D>();

                map.SetTile(finalPosition, null);
                //tileCol.enabled = false;
                //tileCol.enabled = true;
            }

            var half = Vector3.one * 0.5f;
            Instantiate(breakPt, finalPosition + half, Quaternion.identity);

            PoolDestroy();
            return;
        }


    }



    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag(TagName.ExitErea))
        {
            PoolDestroy();
            return;
        }

    }
}
