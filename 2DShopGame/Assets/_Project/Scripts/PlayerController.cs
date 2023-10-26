using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(SkinController))]
public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private SkinController _skinController;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _skinController = GetComponent<SkinController>();

        _playerMovement.SetSkinCallback(_skinController.SetAnimatorValues);
    }
}
