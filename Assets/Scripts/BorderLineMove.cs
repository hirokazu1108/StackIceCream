using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderLineMove : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;

    [SerializeField] GameObject iceParent;

    [SerializeField] GameObject gameController;
    private GameController gameControllerCs;

    void Start()
    {
        gameControllerCs = gameController.GetComponent<GameController>();
    }

    void Update()
    {
        /* �J�����̈ړ��ɍ��킹�� */
        this.transform.position = new Vector3(0, mainCamera.transform.position.y - 4.3f, 0);

        
        if (JudgeGameOver())
        {
            gameControllerCs.GameOver("Game Over");
        }
    }


    /* �{�[�_�[���C���ɂ��Q�[���I�[�o�[�̔��� */
    bool JudgeGameOver()
    {
        if(iceParent.transform.childCount != 0)
        {
            for (int i = 0; i < iceParent.transform.childCount; i++)
            {
                if (iceParent.transform.GetChild(i).gameObject.transform.position.y+1 > this.transform.position.y)
                {
                    return false;
                }
            }
        }
        else
        {
            /* -3.43�̓R�[���̏㕔��y���W */
            if(this.transform.position.y < -3.43f)
            {
                return false;
            }
        }
        

        return true;
    }

}
