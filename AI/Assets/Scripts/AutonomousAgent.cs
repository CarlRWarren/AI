using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousAgent : MonoBehaviour
{
    [SerializeField] string m_targetTag = "";
    [SerializeField] AutonomousBehaviour/*[]*/ m_behaviour = null;
    [SerializeField] [Range(0.0f, 20.0f)] float m_maxSpeed = 0.0f;
    [SerializeField] [Range(0.0f, 50.0f)] float m_maxForce = 0.0f;

    public Vector3 position { get { return transform.position; } set { transform.position = value; } }
    public Vector3 acceleration { get; set; } = Vector3.zero;
    public Vector3 velocity { get; set; } = Vector3.zero;
    public Vector3 forward { get { return velocity.normalized; } }
    public float maxSpeed { get { return m_maxSpeed; } }
    public float maxForce { get { return m_maxForce; } }
    
    void Update()
    {
        acceleration = Vector3.zero;
        GameObject target = (m_targetTag != "") ? GetNearestGameObject(gameObject, m_targetTag) : null;
        AutonomousAgent targetAgent = (target) ? target.GetComponent<AutonomousAgent>() : null;

        Vector3 force = m_behaviour.Execute(this, targetAgent);
        force.y = 0.0f;
        ApplyForce(force);

        velocity += acceleration; //* Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;
        transform.position = WrapPosition(transform.position, new Vector3(-10.0f, -10.0f, -10.0f), new Vector3(10.0f, 10.0f, 10.0f));

        Debug.DrawLine(transform.position, transform.position + velocity, Color.red);
    }

    void ApplyForce(Vector3 force)
    {
        acceleration = acceleration + force;
    }

    Vector3 WrapPosition (Vector3 position, Vector3 min, Vector3 max)
    {
        Vector3 newPosition = position;

        if (position.x > max.x) newPosition.x = min.x + (position.x - max.x);
        if (position.x < min.x) newPosition.x = max.x - (min.x - position.x);
        if (position.y > max.y) newPosition.y = min.y + (position.y - max.y);
        if (position.y < min.y) newPosition.y = max.y - (min.y - position.y);
        if (position.z > max.z) newPosition.z = min.z + (position.z - max.z);
        if (position.z < min.z) newPosition.z = max.z - (min.z - position.z);

        return newPosition;
    }

    public GameObject GetNearestGameObject(GameObject sourceGameObject, string tag, float maxDistance = float.MaxValue)
    {
        GameObject nearest = null;
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag(tag);
        if (gameObjects.Length > 0)
        {
            float nearestDistance = float.MaxValue;
            for (int i = 0; i < gameObjects.Length; i++)
            {
                if (gameObjects[i] != sourceGameObject)
                {
                    float distance = (sourceGameObject.transform.position - gameObjects[i].transform.position).magnitude;
                    if (distance < nearestDistance)
                    {
                        nearest = gameObjects[i];
                        nearestDistance = distance;
                    }
                }
            }
            if (nearestDistance > maxDistance) nearest = null;
        }
        return nearest;
    }
}
