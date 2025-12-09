using UnityEngine;

public class DeadParent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponentInParent<EnemyBase>().isDead) return;

        Destroy(gameObject);
    }
}
