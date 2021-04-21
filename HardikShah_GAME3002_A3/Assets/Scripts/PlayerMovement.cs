using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_Velocity = Vector3.zero;

    [SerializeField]
    private Vector3 m_MaxVelocity = Vector3.zero;

    [SerializeField]
    private float m_MaxAcceleration = 0.0f;

    private bool m_bIsAccelerating = true;
    private Rigidbody m_rb = null;

    private float m_fStartTimeStamp = 0.0f;
    public float Speed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_fStartTimeStamp = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))                                     //Going Forward
        {
            
            m_Velocity.y += m_MaxAcceleration * Time.deltaTime;
            m_Velocity = Vector3.Min(m_Velocity, m_MaxVelocity);
        }

        if(Input.GetKey(KeyCode.Space))                                 //Jumping Key Spacebar
        {
          m_rb.AddForce(Vector2.up * Speed);
        }
    }

    private void FixedUpdate()
    {
            m_rb.AddRelativeForce(m_Velocity);
    }
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "SpeedUpZone")                                         //Speed Up Zone increase the speed
        {
             GetComponent<Renderer>().material.color = Color.black;
             m_Velocity.y += m_MaxAcceleration * Time.deltaTime;
               
             m_Velocity = Vector3.Min(m_Velocity, m_MaxVelocity);
        }

        if(other.tag == "SlowDownZone")                                         //Slow Down will decrease the speed
        {
            m_bIsAccelerating = !m_bIsAccelerating;
            GetComponent<Renderer>().material.color = Color.green;
            m_Velocity.y = 10;
            m_Velocity = Vector3.Min(m_Velocity, m_MaxVelocity);         
        }

        if(other.tag == "MatchEnd")                                             //If the player reach endpoint then nothing happens. the Time will pause and game pause
        {
            
              Debug.Log("Match completed in : " + (Time.time - m_fStartTimeStamp) + " seconds ");
              Time.timeScale = 0f;
        }
    }
}
