using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))] 
public class Node : MonoBehaviour
{
    public static Node SelectedNode;
    private Animator m_Animator;
    private bool IsSelected = false;
    public bool isOcuped;
    public Tower towerOcuped;
    private void Awake() 
    {
        m_Animator = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        if (isOcuped)
        {
            TowerUIPanelManager.instance.OpenPanel(towerOcuped);
            return;
        }
        if (SelectedNode && SelectedNode != this)
        {
            SelectedNode.OnCloseSelection();
        }
        SelectedNode = this;

        IsSelected = !IsSelected;
        if (IsSelected) 
        {
            TowerRequestManager.instance.OnOpenRequestPanel();
        }
        else
            TowerRequestManager.instance.OnCloseRequestPanel();
        m_Animator.SetBool("IsSelected", IsSelected);
    }
    public void OnCloseSelection()
    {
        IsSelected = false;
        m_Animator.SetBool("IsSelected", IsSelected);
    }
}