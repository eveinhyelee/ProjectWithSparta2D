using UnityEngine;

[CreateAssetMenu(fileName = "DefalutAttackSO", menuName = "TopDownController/Attacks/Defalut", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float size;
    public float delay;
    public float power;
    public float speed;
    public LayerMask target; //공격이 어디에 맞는지

    [Header("Knock Back Info")]
    public bool isOnKnockBack;
    public float knockbackPower;
    public float knockbackTime;
}
