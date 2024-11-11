using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D movementRigidbody;
    private CharacterStatsHandler characterStatsHandler;

    private Vector2 movementDrection = Vector2.zero;
    

    private void Awake()
    {
        //주로 내 컴포넌트 안에서 끝나는거
        //controller 랑 TopDownMovement랑 같은 게임오브젝트 안에 있다라는 가정
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        characterStatsHandler = GetComponent<CharacterStatsHandler>();
    }
    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        movementDrection = direction;
    }
    private void FixedUpdate()
    {
        // 물리업데이트 관련
        // rigidbody의 값을 바꾸니까 FixedUpdate
        ApplyMovement(movementDrection);
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * characterStatsHandler.CurrentStat.speed; //지금 현재스피드를 가져옴
        movementRigidbody.velocity = direction;
    }
}

