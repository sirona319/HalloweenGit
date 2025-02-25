using UnityEngine;
using UnityEngine.Audio;

public class CreateDeadSound : MonoBehaviour
{
    //public AudioSource deadSound;

    public bool IsSoundEnable = true;

    [SerializeField] AudioSource audioSe;

    //[SerializeField] AudioResource audioSe;


    public bool Create()
    {
        if (!IsSoundEnable) return IsSoundEnable;
        var seGo = Instantiate(audioSe, transform.position, Quaternion.identity);
        seGo.GetComponent<SoundEndDestroy>().StartDestroyFlg();//削除登録

        return IsSoundEnable;
    }
}
