using UnityEngine;

public class StepLiquid : StepAtomicBase
{
    private void OnEnable()
    {
        TotalSteps = 3;
        StartStep();
        Debug.Log("StepLiquid");
    }
    protected override void ExecuteCurrentStep()
    {
        //Debug.Log("Step step: " + CurretSteps);
        switch (CurretSteps)
        {
            case 0:
                Debug.Log("Liquid step 0: Place the flask at Bunsen bunrner's position" );
                StepTutorialManager.Instance.GotoState(2);
                break;
            case 1:
                Debug.Log("Liquid step 1: Turn on the lighter");
                StepTutorialManager.Instance.GotoState(3);
                break;
            case 2:
                Debug.Log("Liquid step 2: Use the magnifying");
                StepTutorialManager.Instance.GotoState(4);
                break;
        }
    }
}
