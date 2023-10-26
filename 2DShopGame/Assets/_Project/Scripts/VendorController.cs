using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;

public class VendorController : MonoBehaviour//, IClickable
{
    [SerializeField] private float _minDistance;

    private Transform _playerTransform;
    private IEnumerator CheckDistanceCoroutine;

    private void OnMouseDown()
    {
        TryOpenShop();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OnCollisionEnter2D");
        if (other.transform.CompareTag("Player"))
        {
            TryOpenShop();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {

    }
    // private void OnMouseUp() { }

    public void TryOpenShop()
    {
        _playerTransform = AppManager.Player.transform;
        if (Vector2.Distance(transform.position, _playerTransform.position) > _minDistance) return;

        OpenShop();
    }

    private void OpenShop()
    {
        AppManager.UIViewManager.OpenView(UIViewType.Shop);

        if (CheckDistanceCoroutine != null) return;

        StartCoroutine(CheckDistance());
    }

    private IEnumerator CheckDistance()
    {
        while (Vector2.Distance(transform.position, _playerTransform.position) < _minDistance)
        {
            yield return null;
        }

        CheckDistanceCoroutine = null;
        CloseShop();
    }

    private void CloseShop()
    {
        AppManager.UIViewManager.CloseView(UIViewType.Shop);
    }
}
