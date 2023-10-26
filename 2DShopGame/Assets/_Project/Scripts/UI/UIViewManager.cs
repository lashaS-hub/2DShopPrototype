using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIViewManager : MonoBehaviour
{
    [SerializeField] private List<UIScreenView> _uiViews;

    

    private UIScreenView FindView(UIViewType viewType) => _uiViews.FirstOrDefault(x => x.ViewType == viewType);

    public void OpenView(UIViewType viewType)
    {
        var view = FindView(viewType);
        view.OpenView();
    }

    public void CloseView(UIViewType viewType)
    {
        var view = FindView(viewType);
        view.CloseView();
    }


}
