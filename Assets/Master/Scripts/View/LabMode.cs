using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class LabMode : MonoBehaviour
{
    public static event Action<int> OnGotoState;
    [SerializeField] private TMP_Dropdown m_DropDownStateOfMatter;
    [SerializeField] private TMP_Dropdown m_DropDownAtomic;
    [SerializeField] private ModelLoader m_ModelLoader;
    private void OnEnable() 
    {
        SetDefaultState();
        m_DropDownStateOfMatter.onValueChanged.AddListener(OnStateChanged);
        m_DropDownAtomic.onValueChanged.AddListener(OnElementChanged);
    }
    private void OnDisable() 
    {
        m_DropDownStateOfMatter.onValueChanged.RemoveListener(OnStateChanged);
        m_DropDownAtomic.onValueChanged.RemoveListener (OnElementChanged);
    } 
    private void OnStateChanged(int index)
    {
        string selectedState = m_DropDownStateOfMatter.options[index].text;
        UpdateElementDropdown(selectedState);
        m_ModelLoader?.LoadStateModel(selectedState);
    }
    private void OnElementChanged(int index)
    {
        string selectedElement = m_DropDownAtomic.options[index].text;
        m_ModelLoader?.LoadElementModel(selectedElement);
    }
    private void UpdateElementDropdown(string state)
    {
        m_DropDownAtomic.ClearOptions();
        //Debug.Log("SelectedState:" + state);
        if (Config.ElementsByState.ContainsKey(state))
        {
            m_DropDownAtomic.AddOptions(Config.ElementsByState[state]);
        }
        else Debug.LogWarning($"[LabMode] No elements found for state: '{state}'. Please check Config.ElementsByState.");
    }
    private void SetDefaultState()
    {
        UpdateElementDropdown(Config.Solid);
    }
}
