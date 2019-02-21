using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class DecisionTreeNode : MonoBehaviour
{
    [SerializeField] string m_descrition = "Description";
    [SerializeField] Color m_inactiveColor = Color.blue;
    [SerializeField] Color m_activeColor = Color.cyan;

    public bool isActive { get; set; } = false;
    TextMeshProUGUI m_text = null;
    Image m_image = null;

    private void OnValidate()
    {
        if (m_text == null)
        {
            m_text = GetComponentInChildren<TextMeshProUGUI>();
        }
        m_text.text = m_descrition;
        name = m_descrition;
    }

    private void Start()
    {
        m_image = GetComponent<Image>();
    }

    private void Update()
    {
        m_image.color = (isActive) ? m_activeColor : m_inactiveColor;
        isActive = false;
    }
    public abstract DecisionTreeNode Execute();
}
