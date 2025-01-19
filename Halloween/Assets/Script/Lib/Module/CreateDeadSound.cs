using UnityEngine;
using UnityEngine.Audio;

public class CreateDeadSound : MonoBehaviour
{
    //public AudioSource deadSound;

    public bool IsSoundEnable = true;

    [SerializeField] AudioSource audioSe;

    //[SerializeField] AudioResource audioSe;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //deadSound = MyLib.GetComponentLoad<AudioSource>("prefab/Sound/JerryDestroySound");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create()
    {
        if (!IsSoundEnable) return;
        var seGo = Instantiate(audioSe, transform.position, Quaternion.identity);
        seGo.GetComponent<SoundEndDestroy>().StartDestroyFlg();//削除登録
    }
}
