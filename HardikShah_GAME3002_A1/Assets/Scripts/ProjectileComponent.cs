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

        CreateLandingDisplay();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void CreateLandingDisplay()
    {
        m_landingDisplay = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        m_landingDisplay.transform.position = Vector3.zero;
        m_landingDisplay.transform.localScale = new Vector3(1f, 0.1f, 1f);

        m_landingDisplay.GetComponent<Renderer>().material.color = Color.blue;
        m_landingDisplay.GetComponent<Collider>().enabled = false;
    }

    public void OnLaunchProjectile()
    {

    }

    private void UpdateLandingPosition()
    {

    }

    private Vector3 GetLandingPosition()
    {
        return Vector3.zero;
    }

    public void OnMoveForward(float value)
    {
        
    }

    public void OnMoveBackward(float value)
    {
      
    }

    public void OnMoveRight(float value)
    {
   
    }

    public void OnMoveLeft(float value)
    {
      
    }
}
