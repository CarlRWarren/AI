using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelector : MonoBehaviour
{
	[SerializeField] Camera[] m_cameras = null;

	public int index { get; set; } = 0;
	public int count { get { return m_cameras.Length; } }

    void Start()
    {
		UpdateCameras();
    }

    public void Next()
    {
		index++;
		if (index == count)
		{
			index = 0;
		}
		UpdateCameras();
	}

	void UpdateCameras()
	{
		for (int i = 0; i < m_cameras.Length; i++)
		{
			m_cameras[i].enabled = (i == index);
		}
	}
}
