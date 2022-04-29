//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class Timer : MonoBehaviour
//{
//    public float timeRemaining = 10;
//    public bool timerIsRunning = false;
//    private static Timer instance;
//    public static Timer Instance // this is the public way of getting the instance of this script
//    {
//        get { return instance; }
//    }

//    private void Awake()
//    {
//        if (Instance != null) // there should only ever be one of these scripts,
//        {
//            Destroy(this.gameObject); // so if there was already one, we destroy this one
//            return;
//        }
//        instance = this; // there wasn't another one of these yet, so we become the Instance

//    }
//    //private void Start()
//    //{
//    //    // Starts the timer automatically
//    //    timerIsRunning = true;
//    //}
//    //void Update()
//    //{
//    //    if (timerIsRunning)
//    //    {
//    //        if (timeRemaining > 0)
//    //        {
//    //            timeRemaining -= Time.deltaTime;
//    //            DisplayTime(timeRemaining);
//    //        }
//    //        else
//    //        {
//    //            Debug.Log("Time has run out!");
//    //            //Messenger.Broadcast(GameEvent.FRUIT_SLICED);
//    //            timeRemaining = 0;
//    //            timerIsRunning = false;
//    //        }
//    //    }
//    //}
//    //void DisplayTime(float timeToDisplay)
//    //{
//    //    timeToDisplay += 1;
//    //    float minutes = Mathf.FloorToInt(timeToDisplay / 60);
//    //    float seconds = Mathf.FloorToInt(timeToDisplay % 60);
//    //    timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
//    //}
//}