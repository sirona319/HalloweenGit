using UnityEngine;

public class SetParent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(TagName.Player))
        {
            //other.GetComponent<PlayerScr>().SetFall();
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(TagName.Player))
        {
            other.transform.SetParent(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(TagName.Player))
        {
            //other.GetComponent<PlayerScr>().SetFall();
            collision.transform.SetParent(transform);
            Debug.Log("SetParent");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag(TagName.Player))
        {
            other.transform.SetParent(null);
            Debug.Log("SetParentNULL");
        }
    }
}
