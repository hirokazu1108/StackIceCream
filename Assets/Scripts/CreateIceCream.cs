using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateIceCream : MonoBehaviour
{
    private int iceSumNum = 0;//ゲーム全体で出たアイスの合計個数.名前の識別に使用
    [SerializeField] GameObject iceCream;
    [SerializeField] Transform parent;
    private RaycastHit2D hitObject;

    void Update()
    {
        /* 左クリックされたなら */
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hitObject = Physics2D.Raycast(mousePos, -Vector2.up);
            if (hitObject)
            {

                if (hitObject.collider.gameObject.name == this.gameObject.name)
                {
                    if(hitObject.collider.gameObject.name == "FlyFlatterSelect")
                    {
                        Instantiate(iceCream, new Vector3(mousePos.x - 10f, mousePos.y - 10f, 0), Quaternion.identity, parent);
                        
                        return;
                    }
                    mousePos.z = 0;
                    GameObject ice = Instantiate(iceCream, mousePos, Quaternion.identity, parent);
                    GameController.servedIceNum++;
                    iceSumNum++;
                    ice.name = ice.name + "(" + iceSumNum + ")";
                }
                    
            }
           
        }
    }

}
