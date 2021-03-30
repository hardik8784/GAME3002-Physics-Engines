using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBallController : MonoBehaviour
{
    public float Lives = 5.0f;
    public float Score = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OuterArea")
        {
            GetComponent<Transform>().position = new Vector3(11.34f, 0.5f, 10.09f);
            Lives = Lives - 1;
            Debug.Log("Lives Left:");
            Debug.Log(Lives);
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Active_Bumper")
        {
            Score = Score + 100;
            Debug.Log("Collide with Active_Bumper");
            Debug.Log(Score);
        }
        if (collision.gameObject.tag == "Passive_Bumper")
        {
            Score = Score + 50;
            Debug.Log("Collide with Passive_Bumper");
            Debug.Log(Score);
        }
    }
}
