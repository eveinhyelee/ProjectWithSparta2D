using System;
using UnityEngine;

public partial class TopDownController : MonoBehaviour
{
    //캐릭터와 몬스터의 공통적인 움직임을 제어하기 위한 스크립트
    public event Action<Vector2> OnMoveEvent; //Action은 무조건 void만 반환, 아니면 Func
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    //아래에 이벤트 함수를 생성해주고, 위와 같이 이벤트 등록해줌 - 이후, 이벤트에 등록/실행해줄 함수생성필요
    
    private float timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set;}
    // protected 접근제한자는 해당 클래스와 이를 상속받은 클래스에서도 접근 가능
    protected CharacterStatsHandler stats { get; private set; }


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
        // 마지막 공격 이후 시간이 공격 지연 시간보다 적으면 시간 증가
        if (timeSinceLastAttack < stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        // 공격 중이고 지연 시간이 지나면 공격 이벤트 호출
        else if(IsAttacking && timeSinceLastAttack >= stats.CurrentStat.attackSO.delay)
        { 
            timeSinceLastAttack = 0f;
            CallAttackEvent(stats.CurrentStat.attackSO);
        }
    }


    public void CallMoveEvent(Vector2 direction)
    { 
        // ?. 연산자를 사용하여 OnMoveEvent가 null이 아니면 호출
        OnMoveEvent?.Invoke(direction); //?. 없으면 말고 있으면 실행
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    private void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}
