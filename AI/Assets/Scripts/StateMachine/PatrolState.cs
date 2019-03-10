using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState<T> : State<T> where T : StateAgent
{
    BoolRef m_foundPlayer = new BoolRef(false);
    BoolRef m_search = new BoolRef(false);

    public PatrolState(T owner, string id)
	{
		m_owner = owner;
        m_id = id;

        Transition transition = new TransitionBool(ref m_owner.m_isDead, true);
        AddTransition(transition, "Death");
        transition = new TransitionBool(ref m_search);
        AddTransition(transition, "Search");
        transition = new TransitionBool(ref m_foundPlayer);
        AddTransition(transition, "Attack");
        transition = new TransitionFloat(ref m_owner.m_energy, 0.0f, TransitionFloat.eCompare.LESS);
        AddTransition(transition, "Recharge");
    }

	public override void Enter()
	{
		Debug.Log("enter patrol");
        EventManager.Instance.AddListener("Search", OnSearchEvent);
        m_search.m_value = false;
	}
	
	public override void Update()
	{
		if (m_owner.waypoint != null)
		{
			Vector3 direction = m_owner.waypoint.transform.position - m_owner.transform.position;
			Quaternion rotation = Quaternion.Lerp(m_owner.transform.rotation, Quaternion.LookRotation(direction, Vector3.up), 15.0f * Time.deltaTime);
			m_owner.rb.MoveRotation(rotation);
			m_owner.rb.velocity = m_owner.transform.forward * 4.0f;
		}

        m_owner.target = m_owner.perception.GetGameObjectWithTag("Player");
        m_foundPlayer.m_value = (m_owner.target != null);
    }
	
	public override void Exit()
	{
		Debug.Log("exit patrol");
        EventManager.Instance.RemoveListener("Search", OnSearchEvent);
	}

    public void OnSearchEvent(EventData data)
    {
        Debug.Log("<color=red>searchevent</color>");
        m_search.m_value = true;
        m_owner.targetPosition = data._v3;
    }
}
