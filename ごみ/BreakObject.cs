using UnityEngine;

public class BreakObject : MonoBehaviour,IDamage
{
    [SerializeField]ParticleSystem breakPt;

    public bool IsDamage { get; set; } = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        breakPt = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/CFXR Magic Poof");
    }

    public bool Damage(int damage)
    {

        Instantiate(breakPt, transform.position, Quaternion.identity);
        //MyLib.MyPlaySound("Sound/SE/wave/damaged1", 0.5f, SoundManager.I.transform.GetChild(0).gameObject);

        IsDamage = true;

        gameObject.SetActive(false);

        return true;

    }

    private void OnCollisionEnter2D(Collision2D ot)
    {
        if(ot.gameObject.CompareTag(TagName.Knife))
        {
            Debug.Log("BREAK");
            //Damage(1);
        }


    }

}
