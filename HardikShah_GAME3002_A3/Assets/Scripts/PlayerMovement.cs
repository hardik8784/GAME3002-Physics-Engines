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

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(m_bIsAccelerating && Input.GetKey(KeyCode.W))
        {
            m_Velocity.y += m_MaxAcceleration * Time.deltaTime;
            m_Velocity = Vector3.Min(m_Velocity, m_MaxVelocity);
        }

        if(Input.GetKey(KeyCode.Space))
        {
          m_rb.AddForce(Vector2.up * 60);
        }
    }

    private void FixedUpdate()
    {
        if(m_bIsAccelerating)
        {
            m_rb.AddRelativeForce(m_Velocity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(m_bIsAccelerating)
        {
            //m_bIsAccelerating = !m_bIsAccelerating;
            GetComponent<Renderer>().material.color = Color.black;

            m_fStartTimeStamp = Time.time;
        }
        else
        {
            Debug.Log("Match completed in : " + (Time.time - m_fStartTimeStamp) + " seconds ");
        }    
    }
}
