using System.Collections;
using UnityEngine;

public class IceMelter : MonoBehaviour
{
    [SerializeField] private GameObject m_MelterObject;
    [SerializeField] private GameObject m_SolidStructureObject;
    [SerializeField] private GameObject m_LiquidStructureObject;
    private float m_MeltTime = 20f;
    private Material m_IceMat;
    private Material m_MelterMat;
   
    private void Awake()
    {
        SetStructureState(true, false);
        m_IceMat = GetComponent<Renderer>().material;
        m_MelterMat = m_MelterObject.GetComponent<Renderer>().material;
        SetAlpha(m_MelterMat, 0f);
    }
    public void StartMelting() => StartCoroutine(MeltRoutine());
    private IEnumerator MeltRoutine()
    {
        float time = 0f;
        float startIceAlpha = m_IceMat.color.a;
        float endIceAlpha = 0f;
        float startWaterAlpha = 0f;
        float endWaterAlpha = 0.2f;

        while (time < m_MeltTime)
        {
            time += Time.deltaTime;
            float t = time / m_MeltTime;
            SetAlpha(m_IceMat, Mathf.Lerp(startIceAlpha, endIceAlpha, t));
            SetAlpha(m_MelterMat, Mathf.Lerp(startWaterAlpha, endWaterAlpha, t));
            yield return null;
        }
        SetAlpha(m_IceMat, endIceAlpha);
        SetAlpha(m_MelterMat, endWaterAlpha);
        SetStructureState(false, true);
    }
    private void SetAlpha(Material mat, float alpha)
    {
        Color c = mat.color;
        c.a = alpha;
        mat.color = c;
    }

    private void SetStructureState(bool solid, bool liquid)
    {
        m_SolidStructureObject.SetActive(solid);
        m_LiquidStructureObject.SetActive(liquid);
    }
}
