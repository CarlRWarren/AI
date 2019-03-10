using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState<T> : State<T> where T : StateAgent
{
    BoolRef m_foundPlayer = new BoolRef(false);
    FloatRef m_searchTimer = new FloatRef(5.0f);
	public SearchState(T owner, string id)
	{
		m_owner = owner;
        m_id = id;

        Transition transition = new TransitionFloat(ref m_searchTimer, 0.0f, TransitionFloat.eCompare.LESS);
        AddTransition(transition, "Patrol");

        transition = new TransitionBool(ref m_foundPlayer);
        AddTransition(transition, "Attack");
	}

	public override void Enter()
	{
        m_searchTimer.m_value = 5.0f;
		Debug.Log("enter attack");
	}

	public override void Update()
	{		
		Vector3 direction = m_owner.targetPosition - m_owner.transform.position;
		Quaternion rotation = Quaternion.Lerp(m_owner.transform.rotation, Quaternion.LookRotation(direction, Vector3.up), 15.0f * Time.deltaTime);
		m_owner.rb.MoveRotation(rotation);
		m_owner.rb.velocity = m_owner.transform.forward * 4.0f;		

		m_owner.target = m_owner.perception.GetGameObjectWithTag("Player");
        m_foundPlayer.m_value = (m_owner.target != null);

        m_searchTimer.m_value -= Time.deltaTime;
        if(direction.sqrMagnitude < 0.2f)
        {
            m_searchTimer.m_value = -1.0f;
        }
	}

	public override void Exit()
	{
		Debug.Log("exit attack");
	}
}
