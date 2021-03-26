using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public float RestPosition = 0.0f;
    public float PressedPosition = 45.0f;
    public float HitStrength = 10000.0f;
    public float FlipperDamper = 150.0f;
    public string InputName;
    HingeJoint Hinge;

    // Start is called before the first frame update
    void Start()
    {
        Hinge = GetComponent<HingeJoint>();
        Hinge.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring Spring = new JointSpring();
        Spring.spring = HitStrength;
        Spring.damper = FlipperDamper;

        if(Input.GetAxis(InputName) == 1)
        {
            Spring.targetPosition = PressedPosition;
        }
        else
        {
            Spring.targetPosition = RestPosition;
        }
        Hinge.spring = Spring;
        Hinge.useLimits = true;
    }
}
