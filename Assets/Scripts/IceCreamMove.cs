using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamMove : MonoBehaviour
{
    [SerializeField] IceType iceType;

    private bool isThrow = false; //��x����������߂Ȃ�����.
    private GameController gameControllerCs;

    void Start()
    {
        gameControllerCs = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        /* �A�C�X���^�ԏ��� */
        if(!isThrow && Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            /* �h���b�O���̃}�E�X�̈ʒu��GameObject���ړ� */
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            this.transform.position = mousePos;

        }

        /* �A�C�X�𗣂����� */
        if (!isThrow && Input.GetMouseButtonUp(0))
        {
            isThrow = true;

            /* GameObject�̂����x,��]�͂�0�ɂ���. */
            Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = 0;

            /* ����Ɋւ��鏈�� */
            gameControllerCs.ShowWantIce(iceType);

        }
        
        /* �A�C�X�����̍��W�����ɂȂ������������ */
        if(this.transform.position.y < -5.0f)
        {

            Destroy(this.gameObject);

        }

    }

}
