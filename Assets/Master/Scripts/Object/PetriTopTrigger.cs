using UnityEngine;

public class PetriTopTrigger : BaseTrigger
{
    [SerializeField] StepSolid m_StepSolid;
    [SerializeField] GameObject m_ParentPetri;
    [SerializeField] GameObject m_EmptyParent;
    [SerializeField] PetriBottomTrigger m_PetriBottomTrigger;
    [SerializeField] IceMelter m_IceMelter;

    protected override void OnEnter(Collider other)
    {
        if (m_PetriBottomTrigger != null && m_PetriBottomTrigger.IsTriggeredFromBottom) return;
        if (other.CompareTag("Solid"))
        {
            m_StepSolid = other.GetComponent<StepSolid>();
            m_StepSolid.GoToNextStep();
            MagnifyingManager.Instance.ActiveMagnifyingObject(true);
            other.transform.SetParent(m_ParentPetri.transform);
            other.tag = "UnSolid";
            m_IceMelter?.StartMelting();
        }
    }
    protected override void OnExit(Collider other)
    {
        if (other.CompareTag("Solid"))
        {
            m_StepSolid = other.GetComponent<StepSolid>();
            m_StepSolid.GoToPrevStep();
            MagnifyingManager.Instance.ActiveMagnifyingObject(false);
            other.transform.SetParent(m_EmptyParent.transform);
        }
    }
}
