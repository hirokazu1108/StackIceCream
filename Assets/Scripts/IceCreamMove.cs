using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamMove : MonoBehaviour
{
    [SerializeField] IceType iceType;

    private bool isThrow = false; //一度離したらつかめなくする.
    private GameController gameControllerCs;

    void Start()
    {
        gameControllerCs = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        /* アイスを運ぶ処理 */
        if(!isThrow && Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            /* ドラッグ中のマウスの位置にGameObjectを移動 */
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            this.transform.position = mousePos;

        }

        /* アイスを離す処理 */
        if (!isThrow && Input.GetMouseButtonUp(0))
        {
            isThrow = true;

            /* GameObjectのもつ速度,回転力を0にする. */
            Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = 0;

            /* お題に関する処理 */
            gameControllerCs.ShowWantIce(iceType);

        }
        
        /* アイスが一定の座標未満になったら消す処理 */
        if(this.transform.position.y < -5.0f)
        {

            Destroy(this.gameObject);

        }

    }

}
