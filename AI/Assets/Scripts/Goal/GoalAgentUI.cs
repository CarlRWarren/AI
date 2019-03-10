using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalAgentUI : MonoBehaviour
{
	[SerializeField] GoalAgent m_agent = null;
	[SerializeField] GoalNeedUI m_goalNeedUI = null;
	[SerializeField] Slider m_moodSlider = null;
	[SerializeField] TextMeshProUGUI m_moodText = null;

	private void Start()
	{
		// add needs ui to agent ui
		float y = 30.0f;
		foreach (GoalNeed need in m_agent.needs)
		{
			GoalNeedUI ui = Instantiate(m_goalNeedUI, transform);
			ui.Create(need);

			Vector2 position = ui.GetComponent<RectTransform>().anchoredPosition;
			position.y = position.y - y;
			y = y + 30.0f;
			ui.GetComponent<RectTransform>().anchoredPosition = position;
		}
	}

	private void Update()
	{
		m_moodSlider.value = m_agent.mood;
		m_moodText.text = m_agent.mood.ToString("0.00");
	}

}
