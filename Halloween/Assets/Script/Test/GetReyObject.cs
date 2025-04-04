using UniRx.Triggers;
using UnityEngine;
using static UnityEngine.Rendering.VolumeComponent;
using UnityEngine.Tilemaps;


//https://orotiyamatano.hatenablog.com/entry/2019/11/07/TilemapRayDelete
public class GetReyObject : MonoBehaviour
{
    //[Inject]
    //private InputService _inputService;

    //private RaycastHit2D _hit;
    //private Vector2 _hitPos;
    //[SerializeField]
    //private GameObject cursorObj;

    //[SerializeField]
    //Tilemap blockTilemap;

    //private void Start()
    //{
    //    //画面をクリックしたら呼ばれる
    //    _inputService.GetClickPos.Subscribe(val =>
    //    {
    //        //クリックするか、クリックを離すと反応
    //        if (val == Vector3.zero)
    //        {    //クリック話したときはマウスの位置が0で来る
    //            return;
    //        }

    //        var position = gameObject.transform.position;
    //        if (Camera.main == null) return;

    //        Vector3 diff = (Camera.main.ScreenToWorldPoint(val) - position).normalized;
    //        _hitPos = diff;
    //        _hit = Physics2D.Raycast(position, diff/*方向*/, 1/*距離*/, LayerMask.GetMask("Ground"));

    //    }).AddTo(gameObject);

    //    //毎フレーム呼ばれる
    //    //this.UpdateAsObservable().Subscribe(_ =>
    //    //{
    //    //    Action();
    //    //}).AddTo(gameObject);
    //}

    //private void Update()
    //{
    //    Action();
    //}

    //private void Action()
    //{
    //    if (_hit.collider == null) return;
    //    var tilePos = blockTilemap.WorldToCell(_hit.point + _hitPos);
    //    blockTilemap.SetTile(tilePos, null);    //消去
    //}


}
