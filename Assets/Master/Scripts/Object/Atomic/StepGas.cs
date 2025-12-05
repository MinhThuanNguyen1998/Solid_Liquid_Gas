using UnityEngine;

public class StepGas : StepAtomicBase
{
    private void OnEnable()
    {
        TotalSteps = 2;
        StartStep();
        Debug.Log("StartStepGas");
    }
    protected override void ExecuteCurrentStep()
    {
        switch (CurretSteps)
        {
            case 0:
                Debug.Log("Solid step 0: Place the tube at pipe station");
                StepTutorialManager.Instance.GotoState(5);
                break;
            case 1:
                Debug.Log("Solid step 1: Use a magnifying glass");
                StepTutorialManager.Instance.GotoState(6);
                break;
        }
    }
}

