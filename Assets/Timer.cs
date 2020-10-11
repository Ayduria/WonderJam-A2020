using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;

    public float newMalus = 1;
    private GameObject enemyLevel;
    private GameObject Spitter;

    public AudioSource normalMusic;
    public AudioSource battleMusic;

    // Start is called before the first frame update
    void Start()
    {
         timerIsRunning = true;
         normalMusic.Play();
         battleMusic.Pause();
    }

    
     
     void Update()
     {
         if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                battleMusic.Pause();
            }
            else
            {

                normalMusic.Pause();
                battleMusic.Play();

                timeRemaining = 0;
                timerIsRunning = false;
 

                Spitter = GameObject.FindGameObjectWithTag("Spitter");

                Spitter.GetComponent<Spitter>().timerEnded = true;


            }
        }
     }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay ++;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
