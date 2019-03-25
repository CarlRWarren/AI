using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Parameter : MonoBehaviour
{
    [SerializeField] string m_id = "";

    public string id { get { return m_id; } }
}
