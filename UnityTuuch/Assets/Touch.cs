using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    [SerializeField] ParticleSystem m_particleSystem = null;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Application.isEditor == false)
        {
            Application.Quit();
        }
        //Application.platform == RuntimePlatform.  whatever platform
        for(int i = 0; i<Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Vector3 screenPosition = Input.GetTouch(i).position;
                screenPosition.z = 10.0f;

                Vector3 position = Camera.main.ScreenToWorldPoint(screenPosition);
                Instantiate(m_particleSystem, position, Quaternion.identity);
            }
        }
    }
}
