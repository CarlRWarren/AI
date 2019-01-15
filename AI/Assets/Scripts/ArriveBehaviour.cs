using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveBehaviour : AutonomousBehaviour
{
    [SerializeField] [Range(0.0f, 50.0f)] float m_radius = 5.0f;

    public override Vector3 Execute(AutonomousAgent agent, AutonomousAgent target, string targetTag)
    {
        if (target == null) return Vector3.zero;
        Vector3 desired = (target.position - agent.position);
        float distance = desired.magnitude;

        desired = desired.normalized * agent.maxSpeed;
        if (distance < m_radius)
        {
            desired = desired * (distance / m_radius);
        }

        Vector3 steering = desired - agent.velocity;
        //steering = Vector3.ClampMagnitude(steering, agent.maxForce);
        return steering;
    }

}
