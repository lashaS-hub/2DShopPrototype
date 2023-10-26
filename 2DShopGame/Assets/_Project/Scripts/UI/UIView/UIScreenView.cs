using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreenView : UIView
{
    public override void OpenView()
    {
        gameObject.SetActive(true);
    }
    
    public override void CloseView()
    {
        gameObject.SetActive(false);
    }

   
}
