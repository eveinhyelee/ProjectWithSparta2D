using UnityEngine;

[CreateAssetMenu(fileName = "DefalutAttackSO", menuName = "TopDownController/Attacks/Defalut", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float size;
    public float delay;
    public float power;
    public float speed;
    public LayerMask target;

    [Header("Knock Back Info")]
    public bool isOnKnockBak;
    public float knockbackPower;
    public float knockbackTime;
    

}
