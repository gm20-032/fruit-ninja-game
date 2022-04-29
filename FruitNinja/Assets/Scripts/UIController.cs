using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    //private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI finalScore;

    [SerializeField] private GameOverPopup gameOverPopup;
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private GameObject blade;
    [SerializeField] private StartPopup startPopup;

    private int popupsOpen = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Messenger.Broadcast(GameEvent.TIME_CHANGE);
        if (Input.GetKeyDown(KeyCode.Escape) && popupsOpen == 0) 
        {
            optionsPopup.Open();
        }
    }

    // update score display
    public void UpdateScore(int newScore)
    {
        scoreValue.text = "Score: " + newScore.ToString();
        finalScore.text = "Final Score: " + newScore.ToString();
    }

    public void UpdateTime(float timeToDisplay)
    {
        timeToDisplay += 1;         //required because countdown displays the second it's counting down to
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
    
    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1;                         // unpause the game
            //Cursor.lockState = CursorLockMode.Locked;   // show the cursor
            blade.SetActive(true);
            Messenger.Broadcast(GameEvent.GAME_ACTIVE);
            //Cursor.visible = false; // hide cursor

        }
        else
        {
            Time.timeScale = 0;                              // pause the game
            //Cursor.lockState = CursorLockMode.None;     // show the cursor
            Messenger.Broadcast(GameEvent.GAME_INACTIVE);
            //Cursor.visible = true; // show cursor
            blade.SetActive(false);
        }
    }
    public void OnPopupsOpen()
    {
        if (popupsOpen == 0)
        {
            Debug.Log(popupsOpen);
            SetGameActive(false);
        }
        popupsOpen++;

    }

    public void OnPopupsClosed()
    {
        popupsOpen--;
        if (popupsOpen == 0)
        {
            Debug.Log(popupsOpen);
            SetGameActive(true);
        }

    }


    public void ShowGameOverPopup()
    {
        gameOverPopup.Open();
    }
}
