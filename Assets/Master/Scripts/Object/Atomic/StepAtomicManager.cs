using UnityEngine;

public class StepAtomicManager : MonoBehaviour
{
    [SerializeField] private StepSolid m_StepSolid;
    [SerializeField] private StepLiquid m_Liquid;
    [SerializeField] private StepGas m_StepGas;

    public void SetState(string state)
    {
        switch (state)
        {
            case Config.Solid:
                m_StepSolid.StartStep();
                break;
            case Config.Liquid:
                m_Liquid.StartStep();
                break;
            case Config.Gas:
                m_StepGas.StartStep();
                break;
        }
    }
}
