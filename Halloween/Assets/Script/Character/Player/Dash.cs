using UnityEngine;

public class Dash : MonoBehaviour
{

    Rigidbody2D rb2;

    [SerializeField] Vector3 force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //   rb2.AddForce(transform.right*3, ForceMode2D.Impulse);
        //}
    }
}
