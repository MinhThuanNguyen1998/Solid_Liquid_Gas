using System.Collections.Generic;
using UnityEngine;

public class StructureMovingController : MonoBehaviour
{
    [SerializeField] private float m_Amplitude = 0.01f;
    [SerializeField] private float m_Speed = 2f;

    private List<Transform> m_Children = new List<Transform>();
    private Dictionary<Transform, Vector3> m_OriginalPos = new Dictionary<Transform, Vector3>();

    void Start()
    {
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child == transform) continue;

            m_Children.Add(child);
            m_OriginalPos.Add(child, child.localPosition);
        }
    }
    void Update()
    {
        float t = Time.time * m_Speed;

        foreach (Transform child in m_Children)
        {
            float offset = Mathf.Sin(t + child.GetInstanceID()) * m_Amplitude;
            child.localPosition = m_OriginalPos[child] + new Vector3(offset, offset, 0);
        }
    }
}
