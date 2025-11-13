using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "HeathItemData", menuName = "Data/HeathItemData")]
public class HeathItemDataSO : ItemEffectDataSO
{
    public float HealPercent = 0.1f;
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        Player.Instance.PlayerController.ChangeHealth(HealPercent);
    }
}