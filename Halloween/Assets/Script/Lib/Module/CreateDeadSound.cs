using UnityEngine;
using UnityEngine.Audio;

public class CreateDeadSound : MonoBehaviour
{
    //public AudioSource deadSound;

    bool IsSoundEnable = false;

    [SerializeField] string path;

    //AudioSource audioSe;

    //[SerializeField] AudioResource audioSe;

    //private void Start()
    //{
    //    //audioSe= MyLib.GetComponentLoad<AudioSource>("Prefab/Sound/DestroySound");
    //}


    public void Update()
    {
        if (IsSoundEnable) return;
        if (!GetComponent<EnemyBase>().isDead) return ;
        IsSoundEnable = true;

        MyLib.MyPlayOneSound(path, 0.1f, gameObject);

        //var seGo = Instantiate(audioSe, transform.position, Quaternion.identity);
        //seGo.GetComponent<SoundEndDestroy>().StartDestroyFlg();//削除登録
        //return IsSoundEnable;
    }
}
