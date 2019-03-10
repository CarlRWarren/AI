using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalActionSelector : MonoBehaviour
{
	[SerializeField] Camera m_camera = null;
	[SerializeField] GoalAgent m_agent = null;

	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit))
			{
				GameObject go = raycastHit.collider.gameObject;
				GoalAction action = go.GetComponent<GoalAction>();
				if (action != null)
				{
					m_agent.SetAction(action);
				}

			}
		}
	}
}
