using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private float score = 0.0f;
    public void ChangeToResult()
    {
        score = GameController.iceNum - GameController.dropIceNum * 1.3f - GameController.missWantNum * 0.2f + GameController.clearWantNum * 0.8f - GameController.mixFlyNum * 1.5f + GameController.knockFlyNum * 0.7f;
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
    }

    public void ChangeToPlay()
    {
        SceneManager.LoadScene("Play");
    }
}
