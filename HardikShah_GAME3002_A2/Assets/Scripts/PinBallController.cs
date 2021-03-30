using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinBallController : MonoBehaviour
{
    public Text ScoreText;                      //For the player,UI Score Counter
    public Text LivesText;                      //For the player,UI Lives Counter 
    public float Lives = 5.0f;                  
    public float Score = 0.0f;

    void Update()
    {
        //If Lives equal to zero then game pause in this frame
        if(Lives == 0)
        {
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OuterArea")                                                       //If Ball go out of bound or area then this happens
        {
            GetComponent<Transform>().position = new Vector3(11.34f, 0.5f, 10.09f);
            Lives = Lives - 1;
            LivesText.text = "Lives: " + Lives.ToString();
        }
        if (other.tag == "Bash_Toy")                                                        //This is for Bonus points
        {
            Score = Score + 500;
            ScoreText.text = "Score: " + Score.ToString();
            Debug.Log("Trigger with Bash_Toy : " + Score.ToString());
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Active_Bumper")                                    //If Ball Collide with Active Bumper then this happens
        {
            Score = Score + 100;
            ScoreText.text = "Score: " + Score.ToString();
        }
        if (collision.gameObject.tag == "Passive_Bumper")                                   //If Ball Collide with Passive Bumper then this happens
        {
            Score = Score + 50;
            ScoreText.text = "Score: " + Score.ToString();
        }
        if (collision.gameObject.tag == "Bash_Toy")                                         //If Ball Collide with Bash Toy then this happens
        {
            Score = Score + 500;
            ScoreText.text = "Score: " + Score.ToString();
            Debug.Log("Collide with Bash_Toy : " + Score.ToString());
        }
    }
}
