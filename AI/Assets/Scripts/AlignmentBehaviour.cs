using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentBehaviour : AutonomousBehaviour
{
    public override Vector3 Execute(AutonomousAgent agent, AutonomousAgent target, string targetTag)
    {
        Vector3 steering = Vector3.zero;
        //Get all game objects in perception radius
        GameObject[] gameObjects = AutonomousAgent.GetGameObjects(gameObject, targetTag, perception);
        if(gameObjects.Length>0)
        {
            //get sum of all agents within perception
            Vector3 sum = Vector3.zero;
            foreach(GameObject obj in gameObjects)
            {
                AutonomousAgent targetAgent = (obj) ? obj.GetComponent<AutonomousAgent>() : null;
                sum += targetAgent.velocity;
            }
            Vector3 averageVelocity = sum/ gameObjects.Length;
            //align to average velocity
            Vector3 desired = averageVelocity.normalized * agent.maxSpeed;
            steering = desired - agent.velocity;
        }
        return steering;
    }

}
