using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] GameObject go;
    //[SerializeField] AudioResource audioSe;

    bool isDropEnd = false;

    //確率変数など

    //ランダムにする？
    private void Start()
    {
     
    }

    private void Update()
    {
        if(!GetComponent<EnemyBase>().isDead) return;
        if(isDropEnd) return;

        Instantiate(go, transform.position, Quaternion.identity);
        isDropEnd = true;
        
    }

}
