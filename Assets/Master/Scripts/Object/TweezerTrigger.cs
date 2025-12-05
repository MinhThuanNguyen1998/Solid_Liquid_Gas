using UnityEngine;

public class TweezerTrigger : BaseTrigger
{
    [SerializeField] private MovingObjectByMouse m_MovingObjectByMouse;
    [SerializeField] private Transform m_ClampPoint;
    [SerializeField] GameObject m_ParentTweezer;
    [SerializeField] GameObject m_EmptyParent;
    private void ClampSolid(Collider other)
    {
        if (!other.CompareTag("Solid")) return;
        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) return;
        rb.isKinematic = true;
        rb.useGravity = false;
        other.transform.position = m_ClampPoint.position;
        other.transform.SetParent(m_ParentTweezer.transform);
    }
    private void ReleaseSolid(Collider other)
    {
        if (!other.CompareTag("Solid")) return;
        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) return;
        rb.isKinematic = false;
        rb.useGravity = true;
        other.transform.SetParent(m_EmptyParent.transform);
    }
    protected override void OnEnter(Collider other)
    {
        if (!m_MovingObjectByMouse.m_IsDragging) return;
        ClampSolid(other);
    }
    protected override void OnStay(Collider other)
    {
        if (!m_MovingObjectByMouse.m_IsDragging) return;
        ClampSolid(other);
    }
    protected override void OnExit(Collider other)
    {
        ReleaseSolid(other);
    }
}
