using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionAgent : MonoBehaviour
{
    [SerializeField] DecisionTreeNode m_root = null;
    void Update()
    {
        m_root.Execute();
    }
}
