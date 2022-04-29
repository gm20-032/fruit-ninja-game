using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private UIController ui;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem splatterParticle;

    //[SerializeField] private SoundManager sm;
   // [SerializeField] private AudioSource audioSrc;
    //[SerializeField] private AudioClip sliceSound;
    [SerializeField] private AudioClip melonCutSound;
    [SerializeField] private AudioClip explosionSound;
    

    private int score = 0;
    private float timeRemaining = 10;
    private bool timerIsRunning = false;
    private bool isActive = true;

    void Awake()
    {
        //Timer.Instance.timeRemaining = 10;
        //Timer.Instance.timerIsRunning = true;
        timeRemaining = 10;
        timerIsRunning = true;
        Messenger.AddListener(GameEvent.FRUIT_SLICED, this.OnFruitSliced);
        Messenger.AddListener(GameEvent.BOMB_SLICED, this.OnBombSliced);
        Messenger.AddListener(GameEvent.TIME_CHANGE, this.OnTimeChange);
       
        Messenger.AddListener(GameEvent.POPUP_OPENED, ui.OnPopupsOpen);
        Messenger.AddListener(GameEvent.POPUP_CLOSED, ui.OnPopupsClosed);

        Messenger.AddListener(GameEvent.GAME_INACTIVE, OnGameInActive);
        Messenger.AddListener(GameEvent.GAME_ACTIVE, OnGameActive);

        Messenger.AddListener(GameEvent.RESTART_GAME, OnRestartGame);
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.FRUIT_SLICED, this.OnFruitSliced);
        Messenger.RemoveListener(GameEvent.BOMB_SLICED, this.OnBombSliced);
        Messenger.RemoveListener(GameEvent.TIME_CHANGE, this.OnTimeChange);

        Messenger.RemoveListener(GameEvent.GAME_INACTIVE, OnGameInActive);
        Messenger.RemoveListener(GameEvent.GAME_ACTIVE, OnGameActive);
        Messenger.RemoveListener(GameEvent.RESTART_GAME, OnRestartGame);

        Messenger.RemoveListener(GameEvent.POPUP_OPENED, ui.OnPopupsOpen);
        Messenger.RemoveListener(GameEvent.POPUP_CLOSED, ui.OnPopupsClosed);
    }
    void OnFruitSliced()
    {
        score+=10;
        ui.UpdateScore(score);
        splatterParticle.Play();
        SoundManager.Instance.PlaySfx(melonCutSound);
    }

    void OnBombSliced()
    {
        score -= 50;
        ui.UpdateScore(score);
        explosionParticle.Play();
        SoundManager.Instance.PlaySfx(explosionSound);
    }

    void OnTimeChange()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                ui.UpdateTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                //Messenger.Broadcast(GameEvent.RESTART);
                ui.ShowGameOverPopup();
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void OnGameActive()
    {
        isActive = true;
        Debug.Log(isActive);

    }

    public void OnGameInActive()
    {

        isActive = false;
        Debug.Log(isActive);
    }

    public void OnRestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    
}


