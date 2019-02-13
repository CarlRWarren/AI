using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perception : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 90.0f)] float m_fov = 45.0f;
    List<GameObject> m_gameobjects = new List<GameObject>();
    void Update()
    {
        foreach(GameObject go in m_gameobjects)
        {
            Vector3 direction = go.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);
            Color color = (angle <= m_fov) ? Color.green : Color.red;
            Debug.DrawLine(transform.position, go.transform.position, color);
        }
    }

    public GameObject GetGameObjectWithTag(string tag)
    {
        GameObject target = null;
        foreach (GameObject go in m_gameobjects)
        {
            if (go.CompareTag(tag))
            {
                Vector3 direction = go.transform.position - transform.position;
                float angle = Vector3.Angle(direction, transform.forward);
                if (angle < m_fov)
                {
                    target = go;
                    break;
                }
            }
        }
        return target;
    }

    private void OnTriggerEnter(Collider other)
    {
        m_gameobjects.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        m_gameobjects.Remove(other.gameObject);
    }
}
