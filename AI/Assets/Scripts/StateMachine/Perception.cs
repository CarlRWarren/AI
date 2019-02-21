using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perception : MonoBehaviour
{
	[SerializeField] [Range(0.0f, 90.0f)] float m_fov = 45.0f;
	List<GameObject> m_gameObjects = new List<GameObject>();

    void Update()
    {
        foreach(GameObject go in m_gameObjects)
		{
			Vector3 direction = go.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);
			Color color = (angle <= m_fov) ? Color.green : Color.red;
			//Debug.DrawLine(transform.position, go.transform.position, color);
		}
    }

	public GameObject GetGameObjectWithTag(string tag)
	{
		GameObject target = null;

		foreach (GameObject go in m_gameObjects)
		{
			if (go.CompareTag(tag))
			{
				Vector3 direction = go.transform.position - transform.position;
                direction.y = 0.0f;
				float angle = Vector3.Angle(direction, transform.forward);
				if (angle < m_fov)
				{
                    if (Physics.Raycast(transform.position, direction, out RaycastHit hit))
                    {
                        Debug.DrawLine(transform.position, hit.point, Color.red, 5.0f);
                        if (hit.collider.gameObject == go)
                        {
                            target = go;
                            break;
                        }
                    }
                }
			}
		}

		return target;
	}
	
	private void OnTriggerEnter(Collider other)
	{
		m_gameObjects.Add(other.gameObject);		
	}

	private void OnTriggerExit(Collider other)
	{
		m_gameObjects.Remove(other.gameObject);
	}
}
