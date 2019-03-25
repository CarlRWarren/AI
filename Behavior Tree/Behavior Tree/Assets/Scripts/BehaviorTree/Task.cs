using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Task : MonoBehaviour
{
    public enum eStatus
    {
        INVALID,
        SUCCESS,
        FAIL,
        RUNNING
    }

    [SerializeField] protected List<Task> m_children = null;
	[SerializeField] protected eStatus m_status = eStatus.INVALID;

	protected Image m_image;

    protected virtual void OnInitialize() { }
    protected abstract eStatus OnUpdate();
    protected virtual void OnTerminate(eStatus status) { }

    private void Start()
    {
        m_image = GetComponentInChildren<Image>();
    }

    public virtual eStatus Execute()
    {
        if (m_status != eStatus.RUNNING) OnInitialize();
        m_status = OnUpdate();
        if (m_status != eStatus.RUNNING) OnTerminate(m_status);

		UpdateStatusUI();
        UpdateLinkUI();

        return m_status;
    }

	public void UpdateStatusUI(bool reset = false)
    {
        if (m_image)
        {
            Color color = Color.black;
            switch (m_status)
            {
                case eStatus.FAIL: color = Color.red; break;
                case eStatus.SUCCESS: color = Color.green; break;
                case eStatus.RUNNING: color = Color.yellow; break;
                case eStatus.INVALID: color = Color.black; break;
            }
            m_image.color = (reset) ? Color.gray : color;
        }
    }

    protected void UpdateLinkUI()
    {
        Vector3 position = transform.position;
        foreach (Task task in m_children)
        {
            Debug.DrawLine(position, task.transform.position);
        }
    }
}


