using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeValue = 120;
    public Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (TimeValue > 0)
        {
            TimeValue -= Time.deltaTime;

        }
        else
        {
            TimeValue = 0;
            Time.timeScale = 0f;
        }

        DisplayTime(TimeValue);
    }


    void DisplayTime(float TimeToDisplay)
    {
        if(TimeToDisplay < 0 )
        {
            TimeToDisplay = 0;
        }

        float Minutes = Mathf.FloorToInt(TimeToDisplay / 60);
        float Seconds = Mathf.FloorToInt(TimeToDisplay % 60);

        TimerText.text = string.Format("{0:00}:{1:00}", Minutes, Seconds);
    }
}
