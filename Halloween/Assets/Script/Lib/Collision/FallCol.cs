using UnityEngine;

public class FallCol : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
    //  //  SpawnPoof = GameObject.Find("PoolManagerPoof").GetComponent<Spawner>();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    //Spawner SpawnPoof;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagName.Player))
        {
            //モーションをさせないダメージ
            other.GetComponent<PlayerDamage>().AbsDamage(1);
            other.transform.position = transform.GetChild(0).position;
        }

        //SpawnPoof.Spawn(transform.position, transform.rotation);
    }
}
