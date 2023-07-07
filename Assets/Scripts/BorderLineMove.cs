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
        /* カメラの移動に合わせる */
        this.transform.position = new Vector3(0, mainCamera.transform.position.y - 4.3f, 0);

        
        if (JudgeGameOver())
        {
            gameControllerCs.GameOver("Game Over");
        }
    }


    /* ボーダーラインによるゲームオーバーの判定 */
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
            /* -3.43はコーンの上部のy座標 */
            if(this.transform.position.y < -3.43f)
            {
                return false;
            }
        }
        

        return true;
    }

}
