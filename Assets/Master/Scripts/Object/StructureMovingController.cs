using System.Collections.Generic;
using UnityEngine;

public class StructureMovingController : MonoBehaviour
{
    [Header("Common Settings")]
    [SerializeField] private float m_Amplitude = 0.01f;
    [SerializeField] private float m_Speed = 2f;

    [Header("Gas Settings")]
    [SerializeField] private bool IsGas = false;
    [SerializeField] private float GasRadius = 0.2f;
    [SerializeField] private float GasSpeed = 1f;

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
            if (!IsGas)
            {
                float offset = Mathf.Sin(t + child.GetInstanceID()) * m_Amplitude;
                child.localPosition = m_OriginalPos[child] + new Vector3(offset, offset, 0);
            }
            else
            {
                float gasT = Time.time * GasSpeed;
                float id = child.GetInstanceID() * 0.1f;

                float x = Mathf.PerlinNoise(gasT + id, 0) - 0.5f;
                float y = Mathf.PerlinNoise(0, gasT + id) - 0.5f;
                Vector3 offset = new Vector3(x, y, 0) * GasRadius;
                child.localPosition = m_OriginalPos[child] + offset;
            }
        }
    }
}
