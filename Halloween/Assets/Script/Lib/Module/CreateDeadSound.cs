using UnityEngine;
using UnityEngine.Audio;

public class CreateDeadSound : MonoBehaviour
{
    //public AudioSource deadSound;

    public bool IsSoundEnable = true;

    AudioSource audioSe;

    //[SerializeField] AudioResource audioSe;

    private void Start()
    {
        audioSe= MyLib.GetComponentLoad<AudioSource>("Prefab/Sound/DestroySound");
    }


    public bool Create()
    {
        if (!IsSoundEnable) return IsSoundEnable;
        var seGo = Instantiate(audioSe, transform.position, Quaternion.identity);
        seGo.GetComponent<SoundEndDestroy>().StartDestroyFlg();//削除登録

        return IsSoundEnable;
    }
}
