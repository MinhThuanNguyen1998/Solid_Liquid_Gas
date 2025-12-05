using UnityEngine;

public class MagnifyingManager : Singleton<MagnifyingManager>
{   
    [SerializeField] private GameObject m_MagnifyingObject ;
    private Vector3 m_OriginalPosition;
    private void Start()
    {
        m_OriginalPosition = m_MagnifyingObject.transform.position;
    }
    public void ActiveMagnifyingObject(bool isActive) 
    {
        m_MagnifyingObject.SetActive(isActive);
        if (isActive) m_MagnifyingObject.transform.position = m_OriginalPosition;

    } 

}
