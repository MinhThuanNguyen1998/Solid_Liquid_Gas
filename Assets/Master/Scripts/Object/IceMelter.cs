using System.Collections;
using UnityEngine;

public class IceMelter : MonoBehaviour
{
    [SerializeField] private GameObject m_MelterObject;
    private float m_MeltTime = 10f;
    private Material m_IceMat;
    private Material m_MelterMat;
   
    private void Awake()
    {
        m_IceMat = GetComponent<Renderer>().material;
        m_MelterMat = m_MelterObject.GetComponent<Renderer>().material;

        Color c = m_MelterMat.color;
        c.a = 0f;
        m_MelterMat.color = c;
    }
    public void StartMelting()
    {
        StartCoroutine(MeltRoutine());
    }
    private IEnumerator MeltRoutine()
    {
        float time = 0f;

        float startIceAlpha = m_IceMat.color.a;
        float startMelterAlpha = 0f;
        float endMelterAlpha = 0.2f;

        Color iceColor = m_IceMat.color;
        Color waterColor = m_MelterMat.color;

        while (time < m_MeltTime)
        {
            time += Time.deltaTime;
            float t = time / m_MeltTime;

            iceColor.a = Mathf.Lerp(startIceAlpha, 0f, t);
            m_IceMat.color = iceColor;

            waterColor.a = Mathf.Lerp(startMelterAlpha, endMelterAlpha, t);
            m_MelterMat.color = waterColor;

            yield return null;
        }

        iceColor.a = 0f;
        m_IceMat.color = iceColor;

        waterColor.a = endMelterAlpha;
        m_MelterMat.color = waterColor;
    }

}
