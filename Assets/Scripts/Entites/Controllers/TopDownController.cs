using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    protected bool IsAttacking { get; set;}
    // protected 프로퍼티를 한 이유 : 나만 바꾸고싶지만 가져가는건 내 상속받는 클래스들도 볼수 있게
    protected CharacterStatsHandler stats { get; private set; }

    private float timeSinceLastAttack = float.MaxValue;

    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatsHandler>();
    }

    private void Update()
    {
        HandleAttackDelaty();
    }

    private void HandleAttackDelaty()
    {  
        if (timeSinceLastAttack < stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if(IsAttacking && timeSinceLastAttack >= stats.CurrentStat.attackSO.delay)
        { 
            timeSinceLastAttack = 0f;
            CallAttackEvent();
        }
    }


    public void CallMoveEvent(Vector2 direction)
    { 
        OnMoveEvent?.Invoke(direction); //?. 없으면 말고, 있으면 실행한다.
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    private void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
