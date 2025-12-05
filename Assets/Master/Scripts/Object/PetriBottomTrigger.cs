using UnityEngine;

public class PetriBottomTrigger : BaseTrigger
{
    public bool IsTriggeredFromBottom { get; private set; }
    protected override void OnEnter(Collider other)
    {
        if (other.CompareTag("Solid"))
        {
            IsTriggeredFromBottom = true;
        }
    }
    protected override void OnExit(Collider other)
    {
        if (other.CompareTag("Solid"))
        {
            IsTriggeredFromBottom = false;
        }
    }
}
