using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{

    public GameController Controller;
    //private int Score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Goal")
        {
            Controller.IncrementScore();
            transform.position = GameObject.Find("BallPosition").transform.position;
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
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
