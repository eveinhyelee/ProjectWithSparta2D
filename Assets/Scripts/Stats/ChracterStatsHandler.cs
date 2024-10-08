using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsHandler : MonoBehaviour
{
    //기본스텟과 추가스텟들을 계산래서 최종 스텟을 계산 하는 로직이 있음
    //지금은 그냥 기본 스텟만

    [SerializeField] private CharacterStat baseStat;
    public CharacterStat CurrentStat { get; private set; }
    
    public List<CharacterStat> statModifiers = new List<CharacterStat>(); //추가스텟리스트

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
        //TODO ::지금은 기본 능력치만 적용되지만, 앞으로는 능력치강화기능이 적용된다.
        CurrentStat.statsChangType = baseStat.statsChangType;
        CurrentStat.maxHealth = baseStat.maxHealth;
        CurrentStat.speed = baseStat.speed;
    }
}