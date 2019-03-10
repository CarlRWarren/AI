using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
	[SerializeField] Transform m_target = null;

    void Update()
    {
		transform.LookAt(transform.position + m_target.rotation * Vector3.forward, m_target.rotation * Vector3.up);
    }
}
