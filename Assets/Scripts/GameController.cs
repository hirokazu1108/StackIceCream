using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum IceType
{
    Vanilla = 0,
    Chocolate = 1,
    Strawberry = 2

};

public class GameController : MonoBehaviour
{
    [SerializeField] Transform mainCameraTransform;
    [SerializeField] GameObject uiObjects;

    public static int servedIceNum = 0; //出したアイスの総数
    public static int iceNum = 0; //アイスの残数
    public static int dropIceNum = 0; //ダメになったアイスの総数
    public static int mixFlyNum = 0;  //アイスについたハエの総数　マイナス大きめ
    public static int knockFlyNum = 0; //倒したハエの総数
    public static int missWantNum = 0; //お題ミスの総数
    public static int clearWantNum = 0; //お題成功の総数

    private bool isGameOver = false;

    float scrollSpeed = 0.25f; //画面のスクロール速度


    [SerializeField] Sprite[] iceSprite;
    [SerializeField] GameObject wantedIce;
    private int wantedIceIndex = 0; //ほしいアイスの番号

    [SerializeField] GameObject iceCreamParent;
    [SerializeField] GameObject resultPanel;

    public Sprite hitFlyFlatter;

    /* 制限時間 */
    float seconds = 60.1f;
    [SerializeField] GameObject timeText;

    /* ハエに関する変数 */
    
    int preFlyTime = 60; //ハエを前回生成しようとした時間
    [SerializeField] GameObject fly;
    [SerializeField] GameObject flyParent;
    float[] spawn_x = { -9, 9 };

    [SerializeField] Text countDownText;
    [SerializeField] GameObject startPanel;
    bool startFlag = false;

    void Start()
    {
        /* お題の決定と表示 */
        wantedIceIndex = Random.Range(0, 3);
        wantedIce.GetComponent<Image>().sprite = iceSprite[wantedIceIndex];
        StartCoroutine("GameStart");
    }

    // Update is called once per frame
    void Update()
    {
        if (startFlag)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            if (Input.GetKey(KeyCode.W))
            {
                if (mainCameraTransform.position.y >= 0 && mainCameraTransform.position.y <= 100)
                {
                    mainCameraTransform.Translate(new Vector3(0, 10f * Time.deltaTime, 0));
                    uiObjects.transform.Translate(new Vector3(0, 10f * Time.deltaTime, 0));
                    if (mainCameraTransform.position.y > 100)
                    {
                        mainCameraTransform.position = new Vector3(0, 100, -10);
                        uiObjects.transform.position = new Vector3(0, 100, 0);
                    }
                }

            }
            /*
            if (Input.GetKey(KeyCode.S))
            {
                if (mainCameraTransform.position.y >= 0 && mainCameraTransform.position.y <= 100)
                {
                    mainCameraTransform.Translate(new Vector3(0, -10f * Time.deltaTime, 0));
                    uiObjects.transform.Translate(new Vector3(0, -10f * Time.deltaTime, 0));
                    if (mainCameraTransform.position.y < 0)
                    {
                        mainCameraTransform.position = new Vector3(0, 0, -10);
                        uiObjects.transform.position = new Vector3(0, 0, 0);
                    }
                }
            }
            */

            CheckTimer();
            MoveCamera();
            GenerateFlies();

        }
        
        

    }

    public void ShowWantIce(IceType type)
    {
        /* お題の判定 */
        if((int)type != wantedIceIndex)
        {
            Debug.Log("Miss.");
            missWantNum++; //お題のミス数
        }
        else
        {
            Debug.Log("Correct.");
            clearWantNum++;
        }

        /* 次のお題の決定と表示 */
        wantedIceIndex = Random.Range(0, 3);
        wantedIce.GetComponent<Image>().sprite = iceSprite[wantedIceIndex];
    }

    public void MoveCamera()
    {
            scrollSpeed = 0.15f + ((int)(60 - seconds) / 10) * 0.14f;
        mainCameraTransform.Translate(new Vector3(0, scrollSpeed * Time.deltaTime, 0));
        uiObjects.transform.Translate(new Vector3(0, scrollSpeed * Time.deltaTime, 0));

    }

    public void GameOver(string message)
    {
        isGameOver = true;
        scrollSpeed = 0.0f;
        iceNum = iceCreamParent.transform.childCount;
        dropIceNum = servedIceNum - iceNum;
        for(int i = 0;i < flyParent.transform.childCount;i++)
        {
            Destroy(flyParent.transform.GetChild(i).gameObject);
        }
        resultPanel.SetActive(true);
        resultPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = message; //表示するメッセージを格納
        uiObjects.SetActive(false);
        startFlag = false;
    }
    
    private void CheckTimer()
    {
        if (!isGameOver)
        {
            if (seconds > 0)
            {
                seconds -= Time.deltaTime;
                timeText.GetComponent<Text>().text = $"{(int)seconds}";
            }
            else
            {
                GameOver("Time Up");
            }
        }
        
    }

    void GenerateFlies()
    {
        if(preFlyTime - seconds > 1.0f)
        {
            if (Random.Range(0, 100) > 90.0f)
            {
                Instantiate(fly, new Vector3(spawn_x[(int)Random.Range(0,2)],mainCameraTransform.position.y, 0), Quaternion.identity, flyParent.transform);
                preFlyTime = (int)seconds;
            }
            
        }
    }
    private IEnumerator GameStart()
    {
        countDownText.text = "3";
        // 1秒待つ
        yield return new WaitForSeconds(1.0f);

        countDownText.text = "2";
        // 1秒待つ
        yield return new WaitForSeconds(1.0f);
        countDownText.text = "1";

        // 1秒待つ
        yield return new WaitForSeconds(1.0f);
        countDownText.text = "Start";

        // 0.4秒待つ
        yield return new WaitForSeconds(0.4f);
        countDownText.text = "";
        startPanel.SetActive(false);
        startFlag = true;
    }
}
