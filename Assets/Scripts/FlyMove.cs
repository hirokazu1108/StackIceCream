using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMove : MonoBehaviour
{
    private GameObject mainCamera;
    Vector2 finalTargetPos;
    Vector2 dir;
    private float dirSpan;
    private bool isFlatter = false; //ハエたたきとトリガー判定があるか

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        animator = GetComponent<Animator>();
        SetFinalTargetPos();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("dir_x", dir.x);
        this.transform.Translate(dir.x * Time.deltaTime, dir.y * Time.deltaTime, 0.0f);
        dirSpan += Time.deltaTime;
        if(dirSpan > 0.5f)
        {
            SetDir();
        }

        /* ハエたたきとトリガー判定のある時にマウスクリックが解除されるとハエは倒される処理 */
        if(isFlatter && Input.GetMouseButtonUp(0))
        {
            GameController.knockFlyNum++;
            animator.SetTrigger("end");
            Destroy(this.gameObject);
        }

    }

    /* 目標地点の座標を格納 */
    void SetFinalTargetPos()
    {
        finalTargetPos.x = -1.54f;
        finalTargetPos.y = Random.Range(mainCamera.transform.position.y+2, mainCamera.transform.position.y+5);
        
    }

    /* 進む方向を決める */
    void SetDir()
    {
        dirSpan = 0.0f;
        if ((dir = finalTargetPos - (Vector2)this.transform.position).magnitude < 1.5f)
        {
            dir /= 1.1f;
        }
        else
        {
            float angle = Random.Range(-60, 60);
            dir = Quaternion.Euler(0, 0, angle) * dir;
            dir /= Random.Range(4f, 8f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("IceCream"))
        {
            GameController.mixFlyNum++; //ハエの付着した数
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("FlyFlatter"))
        {
            isFlatter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FlyFlatter"))
        {
            isFlatter = false;
        }
    }
}
