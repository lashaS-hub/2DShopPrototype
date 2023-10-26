using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    private static AppManager _instance;

    [SerializeField] private UIViewManager _uiViewManager;

    public static AppManager Instance => _instance;
    public static UIViewManager UIViewManager => Instance._uiViewManager;

    public static PlayerController Player { get; set; }
    
    public static event Action OnLevelStarted;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        OnLevelStarted();
    }
}
