using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAgent : MonoBehaviour
{
	[SerializeField] Perception m_perception = null;
	[SerializeField] Waypoint m_waypoint = null;

	public Waypoint waypoint {  get { return m_waypoint; } set { m_waypoint = value; } }
	public Perception perception { get { return m_perception; } }

	public GameObject target { get; set; }
	public Rigidbody rb { get ; set; }
	public StateMachine<StateAgent> stateMachine { get; set; }

    public BoolRef m_isDead;
    public FloatRef m_energy = new FloatRef(5.0f);

	void Start()
    {
		rb = GetComponent<Rigidbody>();

		stateMachine = new StateMachine<StateAgent>();
        //patrol
        State<StateAgent> state = new PatrolState<StateAgent>(this);
        Transition<StateAgent> transition = new TransitionBool<StateAgent>(this, ref m_isDead, true);
        state.AddTransition(transition, "Death");
        transition = new TransitionFloat<StateAgent>(this, ref m_energy, 0.0f, TransitionFloat<StateAgent>.eCompare.LESS);
        state.AddTransition(transition, "Recharge");
        stateMachine.AddState("Patrol", state);
		stateMachine.AddState("Attack", new AttackState<StateAgent>(this));
		stateMachine.AddState("Death", new DeathState<StateAgent>(this));
        stateMachine.AddState("Recharge", new RechargeState<StateAgent>(this));

		stateMachine.SetState("Patrol");
	}

	void Update()
    {
        m_energy.m_value -= Time.deltaTime;
		stateMachine.Update();
    }
}
