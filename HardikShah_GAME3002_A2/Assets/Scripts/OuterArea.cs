using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)                                                 //If the Ball go OutSide the Area
    {
        if(other.tag == "OuterArea")
        {
            GetComponent<Transform>().position = new Vector3(11.34f,0.5f, 10.09f);
        }
    }
}
