using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUi = default;
    public Text scoreText = default;
    public Text BestRecordText = default;

    public static int score = 0;
    public static int bestScore = 0;
    public float delay = default;
    public float waitTime = default;

    private bool isGameOver = default;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == false)
        {
            waitTime += Time.deltaTime;
            if (waitTime > delay)
            {
                waitTime = 0f;
                scoreText.text = string.Format("Score : {0}", score);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;

        Debug.LogFormat("GameOverUI null?? {0}", gameOverUi == null);
        gameOverUi.SetActive(true);

        if (bestScore < score)
        {
            bestScore = score;
        }

        BestRecordText.text = string.Format("Score : {0}", bestScore);
    }

}
