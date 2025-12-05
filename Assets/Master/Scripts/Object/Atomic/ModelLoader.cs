using System.Collections.Generic;
using UnityEngine;

public class ModelLoader : MonoBehaviour
{
    [Header("3 Model Prefabs")]
    [SerializeField] private GameObject m_SolidModel;
    [SerializeField] private GameObject m_LiquidModel;
    [SerializeField] private GameObject m_GasModel;
    [SerializeField] private ElementChecker m_ElementChecker;
    private GameObject m_CurrentStateModel;
    private GameObject m_CurrentElementModel;
    private Dictionary<string, GameObject> elementPrefabCache = new();

    private void OnEnable()
    {
        InitializeDefault();
    }
    private void InitializeDefault()
    {
        LoadStateModel(Config.Solid, loadDefaultElement: false);
        LoadElementModel(Config.DefaultState_Solid);
    }
    public void LoadStateModel(string state, bool loadDefaultElement = true)
    {
        ClearCurrentStateModel();
        ClearCurrentElementModel();
        GameObject prefabToLoad = null;
        switch (state)
        {
            case var _ when state == Config.Solid:
                prefabToLoad = m_SolidModel;
                if (loadDefaultElement) LoadElementModel(Config.DefaultState_Solid);
                break;

            case var _ when state == Config.Liquid:
                prefabToLoad = m_LiquidModel;
                if (loadDefaultElement) LoadElementModel(Config.DefaultState_Liquid);
                break;

            case var _ when state == Config.Gas:
                prefabToLoad = m_GasModel;
                if (loadDefaultElement) LoadElementModel(Config.DefaultState_Gas);
                break;
        }
        if (prefabToLoad != null)
        {
            m_CurrentStateModel = Instantiate(prefabToLoad, Vector3.zero, Quaternion.identity);
            m_CurrentStateModel.transform.parent = transform;
        }
    }
    public void LoadElementModel(string elementName)
    {
        //Debug.Log("Atomic:" + elementName); 
        ClearCurrentElementModel();
        if (!elementPrefabCache.TryGetValue(elementName, out GameObject prefabToLoad))
        {
            prefabToLoad = Resources.Load<GameObject>($"Models/{elementName}");
            if (prefabToLoad != null)
            {
                elementPrefabCache[elementName] = prefabToLoad; // Cache prefab
            }
            else
            {
                Debug.LogWarning($"[ModelLoader] Prefab not found for element: {elementName}. Expected path: Resources/Models/{elementName}.prefab");
                return;
            }
        }
        m_CurrentElementModel = Instantiate(prefabToLoad);
        m_CurrentElementModel.transform.parent = transform;
        m_ElementChecker?.OnCheckElement(elementName);
    }
  
    private void ClearModel(ref GameObject model)
    {
        if (model != null)
        {
            Destroy(model);
            model = null;
        }
    }
    private void ClearCurrentStateModel() => ClearModel(ref m_CurrentStateModel);
    private void ClearCurrentElementModel() => ClearModel(ref m_CurrentElementModel);

}
