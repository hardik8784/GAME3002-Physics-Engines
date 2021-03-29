using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterArea : MonoBehaviour
{
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
        if(other.tag == "OuterArea")
        {
            GetComponent<Transform>().position = new Vector3(11.34f,0.5f, 10.09f);
        }
    }
}
