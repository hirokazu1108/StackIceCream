using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    [SerializeField] GameObject iceNumObj;
    [SerializeField] GameObject dropIceNumObj;

    [SerializeField] GameObject mixFlyObj;
    [SerializeField] GameObject knockFlyObj;



    void Start()
    {
        
        iceNumObj.GetComponent<Text>().text = GameController.iceNum + "ŒÂ";
        dropIceNumObj.GetComponent<Text>().text = GameController.dropIceNum + "ŒÂ";
        knockFlyObj.GetComponent<Text>().text = GameController.knockFlyNum + "•C";
        mixFlyObj.GetComponent<Text>().text = GameController.mixFlyNum + "•C";

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
