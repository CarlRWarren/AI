using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchAgent : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 100.0f)] float m_speed = 1.0f;
    [SerializeField] [Range(0.0f, 20.0f)] float m_rotateSpeed = 1.0f;
    [SerializeField] Waypoint m_waypoint = null;
    [SerializeField] ParticleSystem m_particleSystem = null;
    [SerializeField] Perception m_perception = null;

    Rigidbody m_rb = null;

    public Waypoint waypoint { set; get; }

    void Start()
    {
        waypoint = m_waypoint;
        m_rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GameObject target = null;
        if (m_perception)
        {
            target = m_perception.GetGameObjectWithTag("Player");
        }
        if (m_particleSystem)
        {
            ParticleSystem.EmissionModule emission = m_particleSystem.emission;
            emission.rateOverTime = (target) ? 5 : 0;
        }
        if(waypoint)
        {
            Vector3 direcetion = waypoint.transform.position - transform.position;
            Quaternion rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direcetion), m_rotateSpeed * Time.deltaTime);
            m_rb.MoveRotation(rotation);
        }
    }

    private void FixedUpdate()
    {
        float force = (waypoint) ? m_speed : 0.0f;
        //m_rb.AddForce(transform.forward * force, ForceMode.Force);
        m_rb.velocity = transform.forward * force;

    }
}
