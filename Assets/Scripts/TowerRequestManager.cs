using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))] 
public class TowerRequestManager : MonoBehaviour
{
    public List<Tower>towers = new List<Tower>();
    private Animator m_Animator;
    public static TowerRequestManager instance;
    private void Awake()
    {
        if (!instance) 
            instance = this;
        else
            Destroy(instance);
        m_Animator = GetComponent<Animator>();
    }

    public void OnOpenRequestPanel()
    {
        m_Animator.SetBool("IsOpen", true);
    }
    public void OnCloseRequestPanel()
    {
        m_Animator.SetBool("IsOpen", false);
    }

    public void RequestTowerBuy(string towerName)
    {
        var tower = towers.Find(x => x.towerName == towerName);
        var towerGo = Instantiate(tower, Node.SelectedNode.transform.position, tower.transform.rotation);
        Node.SelectedNode.towerOcuped = towerGo;
        Node.SelectedNode.isOcuped = true;
        OnCloseRequestPanel();
        Node.SelectedNode.OnCloseSelection();
        Node.SelectedNode = null;
    }
}