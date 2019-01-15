using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohesionBehaviour : AutonomousBehaviour
{
    public override Vector3 Execute(AutonomousAgent agent, AutonomousAgent target, string targetTag)
    {
        Vector3 steering = Vector3.zero;
        //Get all game objects in perception radius
        GameObject[] gameObjects = AutonomousAgent.GetGameObjects(gameObject, targetTag, perception);
        if(gameObjects.Length>0)
        {
            //get center of all agents within perception
            Vector3 center = Vector3.zero;
            foreach(GameObject obj in gameObjects)
            {
                AutonomousAgent targetAgent = (target) ? target.GetComponent<AutonomousAgent>() : null;
                center += targetAgent.position;
            }
            center /= gameObjects.Length;
            //seek to center position
            Vector3 desired = (target.position - agent.position).normalized * agent.maxSpeed;
            steering = desired - agent.velocity;
        }
        return steering;
    }

}
