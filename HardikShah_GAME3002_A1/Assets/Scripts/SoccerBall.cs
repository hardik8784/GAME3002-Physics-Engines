using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{

    private int Score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Goal")
        {
            Debug.Log("GOAAL");
            Score++;
            Debug.Log("Score is:" + Score.ToString());
        }
    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
