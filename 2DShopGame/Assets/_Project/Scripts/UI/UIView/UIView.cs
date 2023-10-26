using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIView : MonoBehaviour
{
    public UIViewType ViewType;

    public abstract void OpenView();
    public abstract void CloseView();
}
