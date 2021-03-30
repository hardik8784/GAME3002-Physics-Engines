using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinBallController : MonoBehaviour
{
    public Text ScoreText;
    public Text LivesText;
    public float Lives = 2.0f;
    public float Score = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Lives == 0)
        {
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OuterArea")
        {
            GetComponent<Transform>().position = new Vector3(11.34f, 0.5f, 10.09f);
            Lives = Lives - 1;
            LivesText.text = "Lives: " + Lives.ToString();
            //Debug.Log("Lives Left :  " + Lives.ToString());
            //Debug.Log(Lives);
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Active_Bumper")
        {
            Score = Score + 100;
            //Debug.Log("Collide with Active_Bumper : " + Score.ToString());
            //Debug.Log(Score);
            ScoreText.text = "Score: " + Score.ToString();
        }
        if (collision.gameObject.tag == "Passive_Bumper")
        {
            Score = Score + 50;
            ScoreText.text = "Score: " + Score.ToString();
            //Debug.Log("Collide with Passive_Bumper : " + Score.ToString());
            //Debug.Log(Score);
        }
    }
}
