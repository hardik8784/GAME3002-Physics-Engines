using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerController : MonoBehaviour
{
    float Power;
    public float MaxPower = 1000.0f;
    public Slider PowerSlider;                                                                  //When Pinball reaches to the Trigger,This called activated to start the game
    List<Rigidbody> BallList;                                                                   
    bool BallReadyToRoll;                                                                       //Checking it reaches to the trigger
    Vector3 PinBallPositionUpdate;

    // Start is called before the first frame update
    void Start()
    {
        PowerSlider.minValue = 0.0f;
        PowerSlider.maxValue = MaxPower;
        BallList = new List<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(BallReadyToRoll)
        {
            PowerSlider.gameObject.SetActive(true);
        }
        else
        {
            PowerSlider.gameObject.SetActive(false);
        }

        PowerSlider.value = Power;
        if(BallList.Count > 0)
        {
            BallReadyToRoll = true;
            if(Input.GetKey(KeyCode.Space))
            {
                
                if(Power <= MaxPower)
                {
                    Power += 500 * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
               foreach(Rigidbody r in BallList)
                {
                    r.AddForce(Power*Vector3.forward);                      //Adding Force to push the Ball 
                }
            }
        }
        else
        {
            BallReadyToRoll = false;
            Power = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PinBall"))
        {
            BallList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PinBall"))
        {
            BallList.Remove(other.gameObject.GetComponent<Rigidbody>());
            Power = 0.0f;
        }
    }


}
