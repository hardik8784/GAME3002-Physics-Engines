using UnityEngine.Assertions;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_vInitialVelocity = Vector3.zero;

    private Rigidbody m_rb = null;

    private GameObject m_landingDisplay = null;

    private bool m_bIsGrounded = true;


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

    private void CreateLandingDisplay()
    {
        m_landingDisplay = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        m_landingDisplay.transform.position = Vector3.zero;
        m_landingDisplay.transform.localScale = new Vector3(1f, 0.1f, 1f);
        m_landingDisplay.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        m_landingDisplay.GetComponent<Renderer>().material.color = Color.blue;
        m_landingDisplay.GetComponent<Collider>().enabled = false;
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
        float fTime = 2f * (0f - m_vInitialVelocity.y / Physics.gravity.y);

        Vector3 vFlatVel = m_vInitialVelocity;
        vFlatVel.y = 0f;
        vFlatVel *= fTime;

        return transform.position + vFlatVel;
    }
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
