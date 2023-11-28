using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUIPanelManager : MonoBehaviour
{
    private Tower tower;
    public TextMeshProUGUI towerNameText;
    public TextMeshProUGUI towerDrescriptionText;
    public TextMeshProUGUI towerRangeText;
    public TextMeshProUGUI towerDMGText;
    public TextMeshProUGUI towerVelocityText;
    public TextMeshProUGUI towerSellPriceText;
    public TextMeshProUGUI towerUpgradePriceText;
    public GameObject root;
    public GameObject buttonUpgrade;
    public static TowerUIPanelManager instance;
    private void Awake ()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void OpenPanel (Tower tower)
    {
        if (tower == null)
        {
            Debug.Log("Es necesario pasar un tower");
            return;
        }
        this.tower = tower;
        SetValues();
        root.SetActive(true);
    }

    public void UpdateTower (Tower tower)
    {
        if (tower = null)
        {
            Debug.Log("Tower cannot be null");
            return;
        }
        if (PlayerData.instance.money >= tower.towerUpgradeData[tower.currentIndexUpgrade].upgradePrice)
        {
            tower.currentData = tower.towerUpgradeData[tower.currentIndexUpgrade];
            tower.currentIndexUpgrade++;
            PlayerData.instance.money -= tower.towerUpgradeData[tower.currentIndexUpgrade].upgradePrice;
        }
        else
        {
            Debug.Log("Not have money to upgrade");
        }
    }

    private void SetValues()
    {
        towerNameText.text = tower.towerName;
        towerDrescriptionText.text = tower.towerDescription;
        towerRangeText.text = "Rango: " + tower.currentData.range.ToString();
        towerDMGText.text = "Daño: " + tower.currentData.dmg.ToString();
        towerVelocityText.text = "Velocidad: " + tower.currentData.timetoShoot.ToString();
        towerSellPriceText.text = "$: " + tower.currentData.sellPrice.ToString();
        towerUpgradePriceText.text = "$: " + tower.currentData.upgradePrice.ToString();
    }

    public void ClosePanel()
    {
        root.SetActive(false);
    }
}
