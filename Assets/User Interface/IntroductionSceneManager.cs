using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//Nice to Have: Blinkender nextIndicator? Aber nochmal mit UI Team absprechen.
public class IntroductionSceneManager : MonoBehaviour
{
    public GameObject[] screenArray;
    public GameObject nextIndicator;
    public GameObject readableDeathAnnouncement;
    public GameObject readableDiary;
    public GameObject tap;
    public float timeRemaining = 10;
    public float timeRemainingShowTap = 60;
    int currentSlide = 0;
    public string sceneToLoad;
    int StartTapTimer = 0;

    //Method for setting the next slide active and the current inactive
    public void NextSlide()
    {
        currentSlide++;
        Debug.Log(currentSlide + "currentSlide");
        screenArray[currentSlide - 1].SetActive(false);
        screenArray[currentSlide].SetActive(true);
        if (currentSlide == 1)
        {
            nextIndicator.SetActive(false);
        }
        else if (currentSlide > 8)
        {
            Debug.Log("Change szene");
            SceneManager.LoadScene(sceneToLoad);
        }
        /* if(currentSlide==2 || currentSlide==3){
            tap.SetActive(false);
            StartTapTimer=1;
            timeRemainingShowTap=3;
         }*/
    }

    public void showOrHideDeathAnnouncement()
    {
        //tap.SetActive(false);
        if (readableDeathAnnouncement.active == false)
        {
            readableDeathAnnouncement.SetActive(true);
            tap.SetActive(false);
            StartTapTimer = 0;
        }
        else
        {
            readableDeathAnnouncement.SetActive(false);
        }
    }

    public void showOrHideDiaryentry()
    {
        if (readableDiary.active == false)
        {
            readableDiary.SetActive(true);
            tap.SetActive(false);
            StartTapTimer = 0;
        }
        else
        {
            readableDiary.SetActive(false);
        }
    }

    //Method for setting the current slide inactive and the previous active
    public void PreviousSlide()
    {
        if (currentSlide > 0)
        {
            currentSlide--;
        }
        screenArray[currentSlide].SetActive(true);
        screenArray[currentSlide + 1].SetActive(false);
    }

    // Update is called once per frame


    void Update()
    {
        //This is used to show the next-Indicator at the first screen after 10 seconds. To change this time, use the float timeremaining at the top

        if (nextIndicator.active == false)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                if (currentSlide == 0)
                {
                    nextIndicator.SetActive(true);
                    timeRemaining = 0;
                }
            }
        }
        if (StartTapTimer == 1)
        {
            if (timeRemainingShowTap >= 0.0)
            {
                timeRemainingShowTap -= Time.deltaTime;
            }
            else if (timeRemainingShowTap < 0.5)
            {
                tap.SetActive(true);
            }
        }
    }
}
