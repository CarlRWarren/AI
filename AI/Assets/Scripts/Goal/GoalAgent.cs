using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoalAgent : MonoBehaviour
{
	public enum eState
	{
		IDLE,
		ACTION_START,
		ACTION_IN_PROGRESS,
		ACTION_COMPLETE,
	}

	[SerializeField] NavMeshAgent m_navMeshAgent = null;
	[SerializeField] Animator m_animator = null;
	[SerializeField] GoalAction m_action = null;
    [SerializeField] [Range(-1.0f, 1.0f)] float m_needThreshold = 0.0f;
    [SerializeField] [Range(-1.0f, 1.0f)] float m_overallThreshold = 0.0f;

	public List<GoalNeed> needs { get; set; } = new List<GoalNeed>();
	public eState state { get; set; } = eState.IDLE;
	public float mood { get; set; } = 1.0f;

	void Awake()
	{
		GoalNeed[] goalNeeds = GetComponentsInChildren<GoalNeed>();
		needs.AddRange(goalNeeds);
	}

    private void Start()
    {
        //SetAction(m_action);
    }

    private void Update()
    {
        switch (state)
        {
            case eState.IDLE:
                GoalAction[] actions = FindObjectsOfType<GoalAction>();
                //GoalAction action = SelectBestAction(actions);
                GoalAction action = SelectBestOverallAction(actions);
                if (action != null)
                {
                    SetAction(action);
                }
                break;

            case eState.ACTION_START:
                StartCoroutine(PerformAction(m_action));
                break;

            case eState.ACTION_IN_PROGRESS:
                //
                break;

            case eState.ACTION_COMPLETE:
                StopCoroutine("PerformAction");
                // action results
                ExecuteActionResults(m_action);
                m_action = null;
                state = eState.IDLE;
                break;

            default:
                break;
        }

        // calculate mood
        mood = 0.0f;
        foreach (GoalNeed need in needs)
        {
            mood = mood + need.mood;
        }
        mood = Mathf.Clamp(mood, -1.0f, 1.0f);
    }

    void ExecuteActionResults(GoalAction action)
	{
        foreach(var result in action.results)
        {
            foreach(var need in needs)
            {
                if (result.type == need.type)
                {
                    need.value += result.value;
                    need.value = Mathf.Clamp(need.value, -1.0f, 1.0f);
                    break;
                }
            }
        }
	}

	IEnumerator PerformAction(GoalAction action)
	{
		state = eState.ACTION_IN_PROGRESS;

		// walk to action location
		m_navMeshAgent.updatePosition = true;
		m_navMeshAgent.SetDestination(action.location.position);
		while ((transform.position - action.location.position).magnitude > 0.1f)
		{
			m_animator.SetFloat("Walk", m_navMeshAgent.velocity.magnitude / m_navMeshAgent.speed);
			yield return null;
		}
		m_animator.SetFloat("Walk", 0.0f);
		yield return new WaitForSeconds(0.1f);
		m_navMeshAgent.updatePosition = false;

		// move to action object
		Transform t1 = transform;
		float time = 1.0f;
		while (time > 0.0f)
		{
			time = time - Time.deltaTime;
			time = Mathf.Max(time, 0.0f);
			TransformLerp(t1, action.actionLocation.transform, transform, 1.0f - (time / 1.0f));

			yield return null;
		}
		yield return new WaitForSeconds(0.1f);

		// start action animation
		m_animator.SetBool(action.animationName, true);
		time = action.time;
		while (time > 0.0f)
		{
			time = time - Time.deltaTime;
			yield return null;
		}
		m_animator.SetBool(action.animationName, false);

		// move to action location
		t1 = transform;
		time = 1.0f;
		while (time > 0.0f)
		{
			time = time - Time.deltaTime;
			time = Mathf.Max(time, 0.0f);
			TransformLerp(t1, action.location.transform, transform, 1.0f - (time / 1.0f));

			yield return null;
		}

		state = eState.ACTION_COMPLETE;

		yield return null;
	}

	static public void TransformLerp(Transform t1, Transform t2, Transform tr, float t)
	{
		tr.position = Vector3.Lerp(t1.position, t2.position, t);
		tr.rotation = Quaternion.Lerp(t1.rotation, t2.rotation,t);
	}

	public void SetAction(GoalAction action)
	{
		if (state == eState.IDLE)
		{
			m_action = action;
			state = eState.ACTION_START;
		}
	}

    GoalAction SelectBestAction(GoalAction[] actions)
    {
        GoalAction bestAction = null;

        float lowestMood = 1.0f;
        GoalNeed highestNeed = null;
        foreach(var need in needs)
        {
            if(need.mood < lowestMood)
            {
                lowestMood = need.mood;
                highestNeed = need;
            }
        }

        if (highestNeed != null && lowestMood<m_needThreshold)
        {
            float bestValueChange = 0.0f;
            foreach(var action in actions)
            {
                float value = action.GetResultsChange(highestNeed);
                if (value > bestValueChange)
                {
                    bestValueChange = value;
                    bestAction = action;
                }
            }
        }

        return bestAction;
    }

    GoalAction SelectBestOverallAction(GoalAction[] actions)
    {
        GoalAction bestAction = null;

        float highestMoodDelta = 0.0f;
        foreach(var action in actions)
        {
            float moodDelta = 0.0f;
            foreach(var need in needs)
            {
                if (action.HasResultType(need.type))
                {
                    float valueChange = action.GetResultsChange(need);
                    float value = need.value + valueChange;
                    value = Mathf.Clamp(value, -1.0f, 1.0f);
                    float mood = need.GetMood(value) - need.mood;
                    moodDelta += mood;
                }
            }
            if (Mathf.Abs(moodDelta)>m_overallThreshold && moodDelta > highestMoodDelta)
            {
                highestMoodDelta = moodDelta;
                bestAction = action;
            }
        }

        return bestAction;
    }
}
