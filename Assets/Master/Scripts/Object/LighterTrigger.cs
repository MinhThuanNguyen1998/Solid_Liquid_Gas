using UnityEngine;

public class LighterTrigger : BaseTrigger
{
    [SerializeField] private StepLiquid m_StepLiquid;
    [SerializeField] private BurnerEffectController m_BurnerEffectController;
    private bool m_IsInTrigger = false;

    private void OnEnable() => MouseDragLock.Unblock();
    
    protected override void OnEnter(Collider other)
    {
        if(other.gameObject.tag == "Bunsen")
        {
            //Debug.Log("Bunsen is OnTrigger");
            m_IsInTrigger = true;
        }
    }
    protected override void OnExit(Collider other)
    {
        if (other.gameObject.tag == "Bunsen")
        {
           //Debug.Log("Bunsen is OnExit");
            m_IsInTrigger = false;
        }
    }
    public void TurnOnLighter()
    {
        if (!m_IsInTrigger || m_StepLiquid.CurretSteps <= 0 || m_StepLiquid.CurretSteps >= 2) return;
        //Debug.Log("Turn on the ligther");
        m_StepLiquid.GoToNextStep();
        m_BurnerEffectController.TurnOnEffect();
        MouseDragLock.Block();
        
    }
}
