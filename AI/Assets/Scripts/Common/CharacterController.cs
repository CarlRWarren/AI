using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
	[SerializeField] [Range(1.0f, 50.0f)] float m_speed = 1.0f;
	[SerializeField] [Range(1.0f, 360.0f)] float m_rotateSpeed = 180.0f;

	float yaw { get; set; } = 0.0f;
    Rigidbody m_rb = null;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
	{
		Vector3 translate = Vector3.zero;

        translate.z = -Input.GetAxis("Vertical") * m_speed;
        yaw += Input.GetAxis("Horizontal") * m_rotateSpeed;

		transform.rotation = Quaternion.AngleAxis(yaw, Vector3.up);
        //m_rb.AddForce(transform.rotation * translate, ForceMode.Acceleration);
        m_rb.velocity = transform.rotation * translate;

    }
}
