using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehaviour : AutonomousBehaviour
{
    public override Vector3 Execute(AutonomousAgent agent, AutonomousAgent target)
    {
        Vector3 desired = (agent.position - target.position).normalized * agent.maxSpeed;
        Vector3 steering = desired - agent.velocity;
        steering = Vector3.ClampMagnitude(steering, agent.maxForce);
        return steering;
    }

}
