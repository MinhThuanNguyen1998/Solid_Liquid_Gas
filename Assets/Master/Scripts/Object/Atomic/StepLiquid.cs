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
                Debug.Log("Liquid step 0: Use the pipet to draw up liquid" );
                StepTutorialManager.Instance.GotoState(2);
                break;
            case 1:
                Debug.Log("Solid step 1: Pour liquid from pipet to a tube");
                StepTutorialManager.Instance.GotoState(3);
                break;
            case 2:
                Debug.Log("Solid step 2: Use a magnifying glass");
                StepTutorialManager.Instance.GotoState(4);
                break;
        }
    }
}
