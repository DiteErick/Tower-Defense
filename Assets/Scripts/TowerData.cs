using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerData
{
    [Header("Price")]
    public float buyPrice;
    public float sellPrice;
    public int upgradePrice;
    [Header("Tower Settings")]
    public float range = 10;
    public float dmg = 20;
    public float timetoShoot = 1;

}
