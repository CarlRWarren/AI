using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] float m_speed = 10.0f;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector3 screenPosition = Input.GetTouch(0).position;
                screenPosition.z = 10.0f;

                Vector3 position = Camera.main.ScreenToWorldPoint(screenPosition);
                Vector3 velocity = position - transform.position;
                transform.position = position;
                GetComponent<Rigidbody>().velocity = velocity * m_speed;
            }
        }
    }
}
