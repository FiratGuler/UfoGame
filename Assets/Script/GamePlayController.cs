using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GamePlayController : MonoBehaviour
{
    public static GamePlayController ornek;



    [SerializeField]

    private Text scoreText, endText, bestScoreText, gameOverText;
    public Image info;
    [SerializeField]
    private Button restartButton, PauseButton;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private Sprite[] medalicon;
    [SerializeField]
    private Image medal;
    // Start is called before the first frame update
    private void Awake()
    {
        MakeInstance();
        info.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    void MakeInstance()
    {
    if (ornek == null)
	  {
		 ornek=this;
	  }
    }
    public void PauseGame()
    {
        if (UfoScript.instance!= null)
        {
            if (UfoScript.instance.isCrash)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0;
                endText.text = ""+UfoScript.instance.score;
                bestScoreText.text = "" + DataController.ornek.getHighScore();
                restartButton.onClick.RemoveAllListeners();
                restartButton.onClick.AddListener(() => Resumegame());


            }
        }
    }
    public void goToMenuButton()
    {
        Application.LoadLevel("Menu");
    }
    public void RestartGame()
    {
        Application.LoadLevel("SampleScene");
        gameOverText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
    
    private void Resumegame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(true);
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        info.gameObject.SetActive(false);
    }
    public void SetScore(int score)
    {
        scoreText.text = "" + score;
    }
    public void skoruGoster(int score)
    {
        pausePanel.SetActive(true);
        endText.text =""+ UfoScript.instance.score;
        if (score>DataController.ornek.getHighScore())
        {
            DataController.ornek.setHighScore(score);
        }
        bestScoreText.text = "" + DataController.ornek.getHighScore();

        gameOverText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        
        if (score<=10)
        {
            medal.sprite = medalicon[0];
        }
        else if (score>10 && score < 20)
        {
            medal.sprite = medalicon[1];
        }
        else
        {
            medal.sprite = medalicon[2];
        }

        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(()=>RestartGame());
       
    
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
