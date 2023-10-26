using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseInputController : MonoBehaviour
{
    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

    //         if (hit.collider != null)
    //         {
    //             IClickable clickable = hit.collider.GetComponent<IClickable>();
    //             clickable?.OnClick();
    //         }
    //     }
    // }
}
