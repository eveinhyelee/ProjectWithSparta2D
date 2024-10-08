using UnityEngine;

public enum StatsChangeType
{ 
    Add,
    Multiple,
    Override
}

//�����͸� ����ó�� ����� �� �ְ� ������ִ� Attribute
[System.Serializable]
public class CharacterStat
{
    public StatsChangeType statsChangType;
    [Range(1,100)] public int maxHealth;
    [Range(1f,20f)] public float speed;
    public AttackSO attackSO;
}