using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerController : MonoBehaviour
{
    public float BouncingStrength = 1500.0f;
    private void OnCollisionEnter(Collision collision)                                                  //This is for the Bumpers
    {
        collision.rigidbody.AddExplosionForce(BouncingStrength, this.transform.position, 5.0f);
    }
}
