using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttackSO", menuName = "TopDownController/Attacks/Ranged", order = 1)]
public class RangedAttackSO : AttackSO
{
    [Header("Ranged Attack Info")]
    public string bulletNameTag;
    public float duration;
    public float spread;
    public int numberOfProjectilesPerShot; // 한번나갈때 몇개씩 나가는지
    public float multipleProjectilesAngle; // 몇도 만큼 떨어지는지
    public Color projectileColor;
}