using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerPrefab;
    [SerializeField] private Transform _playerPosition;

    private void Awake()
    {
        AppManager.OnLevelStarted += SpawnPlayer;
    }

    private void SpawnPlayer()
    {
        var player = Instantiate(_playerPrefab, _playerPosition);
        AppManager.Player = player;
    }

    private void OnDestroy()
    {
        AppManager.OnLevelStarted -= SpawnPlayer;
    }
}
