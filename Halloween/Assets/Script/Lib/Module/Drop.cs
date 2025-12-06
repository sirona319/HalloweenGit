using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] GameObject go;

    bool isDropEnd = false;

    private void Update()
    {
        if(!GetComponent<EnemyBase>().isDead) return;
        if(isDropEnd) return;
        isDropEnd = true;

        Instantiate(go, transform.position, Quaternion.identity);

    }

}
