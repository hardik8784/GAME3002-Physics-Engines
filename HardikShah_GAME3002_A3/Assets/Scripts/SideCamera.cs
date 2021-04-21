using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCamera : MonoBehaviour
{
    [SerializeField]
    private Transform m_targetTransform = null;

    private Vector3 m_vOffset;

    // Start is called before the first frame update
    void Start()
    {
        m_vOffset = transform.position - m_targetTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = m_targetTransform.position + m_vOffset;
    }


}
