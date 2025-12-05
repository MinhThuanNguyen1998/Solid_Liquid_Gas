using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using UnityEngine;

public class ElementChecker : MonoBehaviour
{
    [SerializeField] private ElementDisplay m_ElementDisplay;
    private List<ElementData> m_ListElements;
    

    private void Start()
    {
        LoadElementDataFromFileJson();
    }
    private void LoadElementDataFromFileJson()
    {
        string path = Path.Combine(Config.StreamingAssetsPath, Config.ElementsData);
        m_ListElements = JsonLoader.LoadDataFromJson<ElementData>(path);
        OnCheckElement(Config.DefaultState_Solid);
    }
    public void OnCheckElement(string elementName)
    {
        if (m_ListElements == null || m_ListElements.Count == 0)
        {
            //Debug.LogError("Element list is empty!");
            return;
        }
        ElementData data = m_ListElements.FirstOrDefault(e => string.Equals(e.name, elementName, StringComparison.OrdinalIgnoreCase));
        //Debug.Log($"Name: {data.name}\n" + $"Symbol: {data.symbol}\n" + $"Atomic Number: {data.atomicNumber}\n" + $"Atomic Mass: {data.atomicMass}\n" + $"Shells: {string.Join(", ", data.shells)}");
        m_ElementDisplay?.DisplayElementInformation(data.atomicNumber, data.symbol, data.name, data.atomicMass);

    }
}
