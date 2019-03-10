using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionAgent : MonoBehaviour
{
    [SerializeField] DecisionTreeNode m_root = null;
    public int frame { get; set; } = 0;
    void Update()
    {
        frame++;
        m_root.Execute();
    }
}
