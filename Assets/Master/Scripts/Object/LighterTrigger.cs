using UnityEngine;

public class LighterTrigger : BaseTrigger
{
    [SerializeField] private StepLiquid m_StepLiquid;
    [SerializeField] private BurnerEffectController m_BurnerEffectController;
    [SerializeField] private LighterButton m_LighterButton;
    private bool m_IsInTrigger = false;
    
    protected override void OnEnter(Collider other)
    {
        if(other.gameObject.tag == "Bunsen")
        {
            //Debug.Log("Bunsen is OnTrigger");
            m_IsInTrigger = true;
            TurnOnLighter();
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
        if (!m_IsInTrigger || !m_LighterButton.IsFireOn) return;
        m_BurnerEffectController.TurnOnFireEffect();
        
    }
}
