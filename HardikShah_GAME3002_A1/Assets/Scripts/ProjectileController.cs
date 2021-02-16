using UnityEngine.Assertions;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private ProjectileComponent m_projectile = null;                                          // Create the Reference


    // Start is called before the first frame update
    private void Start()
    {
        m_projectile = GetComponent<ProjectileComponent>();                                   // Grabbing the Component
        Assert.IsNotNull(m_projectile, "ProjectileComponent is not attached!");               // Checking that ProjectileComponent is attached or not
    }

    // Update is called once per frame
    private void Update()
    {
        HandleUserInput();                                                                  //insted of putting all the code into here,putting a function and all the work will be done in that function
    }

    private void HandleUserInput()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_projectile.OnLaunchProjectile();
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            m_projectile.OnMoveForward(0.1f);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            m_projectile.OnMoveBackward(0.1f);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            m_projectile.OnMoveRight(0.1f);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            m_projectile.OnMoveLeft(0.1f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            m_projectile.OnMoveUp(0.1f);
        }

        if (Input.GetKey(KeyCode.F))
        {
            m_projectile.OnMoveDown(0.1f);
        }
        
    }

}
