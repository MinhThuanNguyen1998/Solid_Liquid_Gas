using UnityEngine;

public class StoolTrigger : BaseTrigger
{
    [SerializeField] private StepLiquid m_StepLiquid;
    protected override void OnEnter(Collider other)
    {
       if(other.gameObject.tag == "Flask")
       {
            m_StepLiquid.GoToNextStep();
            //Debug.Log("Current Step:" + m_StepLiquid.CurretSteps);
        }
    }
    protected override void OnExit(Collider other)
    {
        if (other.gameObject.tag == "Flask")
        {
            m_StepLiquid.GoToPrevStep();
            //Debug.Log("Current Step:" + m_StepLiquid.CurretSteps);
        }
    }
}
