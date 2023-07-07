using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateIceCream : MonoBehaviour
{
    private int iceSumNum = 0;//�Q�[���S�̂ŏo���A�C�X�̍��v��.���O�̎��ʂɎg�p
    [SerializeField] GameObject iceCream;
    [SerializeField] Transform parent;
    private RaycastHit2D hitObject;

    void Update()
    {
        /* ���N���b�N���ꂽ�Ȃ� */
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
