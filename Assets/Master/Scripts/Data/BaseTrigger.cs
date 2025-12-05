using UnityEngine;

public abstract class BaseTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        OnEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit(other);
    }

    private void OnTriggerStay(Collider other)
    {
        OnStay(other);
    }
    protected virtual void OnEnter(Collider other) { }
    protected virtual void OnExit(Collider other) { }
    protected virtual void OnStay(Collider other) { }
}
