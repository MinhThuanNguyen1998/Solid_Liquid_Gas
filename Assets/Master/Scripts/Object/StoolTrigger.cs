using DG.Tweening;
using UnityEngine;

public class StoolTrigger : BaseTrigger
{
    [SerializeField] private StepLiquid m_StepLiquid;
    [SerializeField] private BurnerEffectController m_BurnerEffectController;
  
    protected override void OnEnter(Collider other)
    {
       if(other.gameObject.tag == "Flask")
       {
            m_StepLiquid.GoToNextStep();
            m_BurnerEffectController.TurnOnBoilingEffect();
            //Debug.Log("Current Step:" + m_StepLiquid.CurretSteps);
        }
    }
    protected override void OnExit(Collider other)
    {
        if (other.gameObject.tag == "Flask")
        {
            m_StepLiquid.GoToPrevStep();
            m_BurnerEffectController.TurnOffBoilingEffect();
            //Debug.Log("Current Step:" + m_StepLiquid.CurretSteps);
        }
    }
}
