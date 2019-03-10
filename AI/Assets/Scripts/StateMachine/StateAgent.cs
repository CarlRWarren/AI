using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StateAgent : MonoBehaviour
{
	[SerializeField] Perception m_perception = null;
	[SerializeField] Waypoint m_waypoint = null;
    [SerializeField] TextMeshProUGUI m_text = null;

	public Waypoint waypoint {  get { return m_waypoint; } set { m_waypoint = value; } }
	public Perception perception { get { return m_perception; } }

	public GameObject target { get; set; }
    public Vector3 targetPosition { get; set; }
	public Rigidbody rb { get ; set; }
	public StateMachineBase<StateAgent> stateMachine { get; set; }

    public BoolRef m_isDead;
    public FloatRef m_energy = new FloatRef(5.0f);

	void Start()
    {
		rb = GetComponent<Rigidbody>();

		stateMachine = new StateMachine<StateAgent>();

        stateMachine.AddState(new PatrolState<StateAgent>(this, "Patrol"));
		stateMachine.AddState(new SearchState<StateAgent>(this, "Search"));
		stateMachine.AddState(new AttackState<StateAgent>(this, "Attack"));
		stateMachine.AddState(new DeathState<StateAgent>(this, "Death"));
        stateMachine.AddState(new RechargeState<StateAgent>(this, "Recharge"));

		stateMachine.SetState("Patrol");
	}

	void Update()
    {
        m_energy.m_value -= Time.deltaTime;
		stateMachine.Update();
        if(m_text != null)
        {
            m_text.text = stateMachine.GetState().m_id;
        }
    }
}
