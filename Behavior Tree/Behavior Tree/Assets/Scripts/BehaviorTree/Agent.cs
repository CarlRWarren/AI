using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
	[SerializeField] Task m_root = null;

	private void LateUpdate()
	{
		m_root.Execute();
	}
}

