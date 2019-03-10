using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalNeedUI : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI m_name = null;
	[SerializeField] Slider m_needSlider = null;
	[SerializeField] TextMeshProUGUI m_mood = null;

	GoalNeed m_need = null;

	public void Create(GoalNeed need)
	{
		m_need = need;
		m_name.text = m_need.type.ToString();
	}

	private void Update()
	{
		m_needSlider.value = m_need.value;
		m_mood.text = m_need.mood.ToString("0.00");
	}
}
