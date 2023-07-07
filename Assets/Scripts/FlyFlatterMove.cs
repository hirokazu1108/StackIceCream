using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyFlatterMove : MonoBehaviour
{
    private GameController gameControllerCs;
    private Sprite hitFlyFlatter;

    void Start()
    {
        gameControllerCs = GameObject.Find("GameController").GetComponent<GameController>();
        hitFlyFlatter = gameControllerCs.hitFlyFlatter;
    }

    void Update()
    {
        /* �n�G���������^�ԏ��� */
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            /* �h���b�O���̃}�E�X�̈ʒu��GameObject���ړ� */
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            this.transform.position = mousePos;

        }

        /* �n�G�������𗣂����� */
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<SpriteRenderer>().sprite = hitFlyFlatter;
            //Invoke("DestroyFlatter", 0.5f);
            DestroyFlatter();
        }
    }

    void DestroyFlatter()
    {
        Destroy(this.gameObject,0.5f);
    }

}
