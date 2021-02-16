using UnityEngine.Assertions;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_vInitialVelocity = Vector3.zero;                                        //Setting our initial velocity

    private Rigidbody m_rb = null;                          

    private GameObject m_landingDisplay = null;

    private bool m_bIsGrounded = true;                                                        //As a safeground to check it is grounded or not after the launch


    // Start is called before the first frame update
    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rb, "Rigidbody is not attached!");
        m_vInitialVelocity.y = 5.0f;
        CreateLandingDisplay();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateLandingPosition();
    }

    private void CreateLandingDisplay()                                                     //Creating the Landing Display
    {
        m_landingDisplay = GameObject.CreatePrimitive(PrimitiveType.Cylinder);              
        m_landingDisplay.transform.position = Vector3.zero;
        m_landingDisplay.transform.localScale = new Vector3(1f, 0.1f, 1f);
        m_landingDisplay.transform.rotation = Quaternion.Euler(90f, 0f, 0f);                //Facing the Player's Direction

        m_landingDisplay.GetComponent<Renderer>().material.color = Color.blue;              //Render the Color into the Game as Blue
        m_landingDisplay.GetComponent<Collider>().enabled = false;                          //Disable the collider so that it will not collide
    }

    
    public void OnLaunchProjectile()
    {
        //if (!m_bIsGrounded)
        //{
        //    return;
        //}

        m_landingDisplay.transform.position = GetLandingPosition();
        //m_bIsGrounded = false;
        transform.rotation = CalculationTools.CalcUtils.UpdateProjectileFacingRotation(m_landingDisplay.transform.position, transform.position);
        //transform.LookAt(m_landingDisplay.transform.position, Vector3.up);

        m_rb.velocity = m_vInitialVelocity;
    }

    private void UpdateLandingPosition()
    {
        if (m_landingDisplay != null && m_bIsGrounded)                          
        {
            m_landingDisplay.transform.position = GetLandingPosition();                     
        }
    }

    private Vector3 GetLandingPosition()
    {
        //T = 2* (Vf- Vi)/g

        float fTime = 2f * (0f - m_vInitialVelocity.y / Physics.gravity.y);

        Vector3 vFlatVel = m_vInitialVelocity;
        //vFlatVel.y = 0f;                                                                   //We can move into any direction.if we don't want to move into Y direction than we can uncomment it
        vFlatVel *= fTime;

        return transform.position + vFlatVel;
    }

    //Creating the function for the changing the projectilecomponent
    #region INPUT_FUNCTIONS
    public void OnMoveForward(float value)
    {
        m_vInitialVelocity.z += value;
    }

    public void OnMoveBackward(float value)
    {
        m_vInitialVelocity.z -= value;
    }

    public void OnMoveRight(float value)
    {
        m_vInitialVelocity.x += value;
    }

    public void OnMoveLeft(float value)
    {
        m_vInitialVelocity.x -= value;
    }

    public void OnMoveUp(float value)
    {
        m_vInitialVelocity.y += value;
    }

    public void OnMoveDown(float value)
    {
        m_vInitialVelocity.y -= value;
    }
    #endregion
}
