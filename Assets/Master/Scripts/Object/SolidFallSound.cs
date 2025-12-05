using UnityEngine;

public class SolidFallSound : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Table")) return;
        AudioMainManager.Instance.PlayOnShot(SoundType.Solid);
    }
    
}
