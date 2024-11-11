using UnityEngine;

public enum StatsChangeType
{ 
    Add,
    Multiple,
    Override
}

//데이터 폴더처럼 사용할 수 있게 만들어주는 Attribute
[System.Serializable]
public class CharacterStat
// 능력치를 변경 처리할 수 있도록 정의한 속성 클래스
{
    public StatsChangeType statsChangType; 
    [Range(1,100)] public int maxHealth; // 최대 체력
    [Range(1f,20f)] public float speed; // 이동 속도
    public AttackSO attackSO; // 공격 관련 스크립터블 오브젝트
}