using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //tao singleton chi an truy cap vao dc instance nay la co the truy cap vao het dc UIManager, h muon truy cap chi can UImanager.Instace.GameStart()
    public static UIManager instance;
    public GameObject taptapPannel;
    public GameObject gameOverPannel;
    public Text score;
    public Text highScore1;
    public Text highScore2;
    public GameObject tapText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore1.text = PlayerPrefs.GetInt("highScore").ToString();
    }
    public void GameStart()
    {
        
        tapText.SetActive(false);
        taptapPannel.GetComponent<Animator>().Play("PannelMoveUpAndDisappear");
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPannel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
