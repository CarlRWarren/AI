using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct EventData
{
	public string sender;
	public string receiver;
	public int _int;
	public float _float;
	public string _string;
	public Vector3 _v3;
}

public class EventManager : Singleton<EventManager>
{
	Dictionary<string, Action<EventData>> m_events = new Dictionary<string, Action<EventData>>();

	public void AddListener(string eventName, Action<EventData> listener)
	{
		Action<EventData> _event;
		if (m_events.TryGetValue(eventName, out _event))
		{
			_event += listener;
			m_events[eventName] = _event;
		}
		else
		{
			_event += listener;
			m_events.Add(eventName, _event);
		}
	}

	public void RemoveListener(string eventName, Action<EventData> listener)
	{
		if (m_events.TryGetValue(eventName, out Action<EventData> _event))
		{
			_event -= listener;
			m_events[eventName] = _event;
		}
	}

	public void SendEvent(string eventName, ref EventData data)
	{
		if (m_events.TryGetValue(eventName, out Action<EventData> _event))
		{
			if (_event != null)
			{
				_event.Invoke(data);
			}
		}
	}
}
