using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuManager : MonoBehaviour
{
    public static menuManager Instance;
    
    [SerializeField] private Menu[] Menus;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName)
    {
        foreach (var Menu in Menus)
        {
            if (Menu.menuName == menuName)
            {
                Menu.Open();
            }
            else
            {
                Menu.Close();
            }
        }
    }

    public void OpenMenu(Menu menu)
    {
        foreach (var Menu in Menus)
        {
            if (Menu == menu)
            {
                Menu.Open();
            }
            else if (Menu.open)
            {
                Menu.Close();
            }
        }
    }
    
    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }
}
