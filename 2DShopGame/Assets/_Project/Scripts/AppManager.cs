using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    private static AppManager _instance;

    [SerializeField] private UIViewManager _uiViewManager;

    public static AppManager Instance => _instance;
    public static UIViewManager UIViewManager => Instance._uiViewManager;

    public static DataContainer GameData { get; private set; }
    public static PlayerController Player { get; set; }

    public static event Action OnLevelStarted;
    public static event Action<ItemDto> OnItemBought;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
            _instance.Init();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Init()
    {
        GameData = new DataContainer();
    }

    private void Start()
    {
        // Deserves separate system, but currently to much effort for game that doesn't have levels
        OnLevelStarted();
    }
}
