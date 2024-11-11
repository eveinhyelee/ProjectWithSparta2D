using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    // 기본 능력치와 추가 능력치의 조합을 통해 현재 능력치를 관리하는 클래스
    // 현재는 기본 능력치만 사용

    [SerializeField] private CharacterStat baseStat;
    public CharacterStat CurrentStat { get; private set; }
    
    public List<CharacterStat> statModifiers = new List<CharacterStat>(); //추가 능력치 리스트
    private void Awake()
    {
        UpdateChracterStat();
    }

    private void UpdateChracterStat()
    {
        AttackSO attackSO = null;
        if (baseStat.attackSO != null)
        { 
            attackSO = Instantiate(baseStat.attackSO);
        }
        CurrentStat = new CharacterStat { attackSO = attackSO };
        //TODO ::현재는 기본 스탯만 적용하지만, 이후 추가 스탯을 반영할 수 있도록 수정 예정
        CurrentStat.statsChangType = baseStat.statsChangType;
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed = baseStat.speed;
    }
}