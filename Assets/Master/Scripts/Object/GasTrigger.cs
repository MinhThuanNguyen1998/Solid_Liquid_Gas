using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GasTrigger : BaseTrigger
{
    [SerializeField] private StepGas m_StepGas;
    [SerializeField] private Material m_OriginMaterial;
    [SerializeField] private Material m_EffectMaterial;
    [SerializeField] private List<Renderer> m_ListRenderer;
    private bool m_IsGasTrigger = false;
    private float m_LerpDuration = 13f;
    private float m_TimeToChangeMaterial = 18f;
    
    protected override void OnEnter(Collider other)
    {
        if (m_IsGasTrigger) return;
        if (other.CompareTag("Pipe"))
        {
            m_StepGas?.GoToNextStep();
            m_IsGasTrigger = true;
            StartCoroutine(LerpMaterial(m_OriginMaterial, m_EffectMaterial, m_LerpDuration));
        }
    }
    private IEnumerator LerpMaterial(Material fromMat, Material toMat, float duration)
    {
        MouseDragLock.Block();
        AudioMainManager.Instance.PlayOnShot(SoundType.Gas);
        float time = 0f;
        while (time < duration)
        {
            float t = time / duration;
            foreach (var renderer in m_ListRenderer)
            {
                if (renderer != null) renderer.material.Lerp(fromMat, toMat, t);
            }
            time += Time.deltaTime;
            yield return null;

        }
        SetMaterial(toMat);
        MouseDragLock.Unblock();
        MagnifyingManager.Instance.ActiveMagnifyingObject(true);
        StepTutorialManager.Instance.GotoState(6);

    }
    private void SetMaterial(Material material)
    {
        if (m_ListRenderer == null) return;
        foreach (var renderer in m_ListRenderer)
        {
            if (renderer != null) renderer.material = material;
        }
    }
}
