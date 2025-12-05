using UnityEngine;
using UnityEngine.UI;

public class MagnifyingColorManager : MonoBehaviour
{
    [SerializeField] private bool m_GetStartingColorFromMaterial;
    [SerializeField] private FlexibleColorPicker m_Fcp;
    [SerializeField] private Material m_NewMaterial;
    [SerializeField] private Material m_DefaultMaterial;
    [SerializeField] private Button m_ResetDefaultMaterialButton;

    private void Start()
    {

        if (m_GetStartingColorFromMaterial)
            m_Fcp.color = m_NewMaterial.color;

        m_Fcp.onColorChange.AddListener(OnChangeColor);
        m_ResetDefaultMaterialButton.onClick.AddListener(OnButtonResetDefaultMaterial);
    }
    private void OnChangeColor(Color co)
    {
        m_NewMaterial.color = co;
    }
    private void OnButtonResetDefaultMaterial()
    {
        m_Fcp.color = m_DefaultMaterial.color;
    }
}
