using TMPro;
using UnityEngine;

public class ElementDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_TextAtomicNumber;
    [SerializeField] private TextMeshProUGUI m_TextSymbol;
    [SerializeField] private TextMeshProUGUI m_TextName;
    [SerializeField] private TextMeshProUGUI m_TextMass;

    public void DisplayElementInformation(string atomic, string symbol, string name, string mass)
    {
        m_TextAtomicNumber.text = atomic;
        m_TextSymbol.text = symbol;
        m_TextName.text = name;
        m_TextMass.text = mass;
    }
}
