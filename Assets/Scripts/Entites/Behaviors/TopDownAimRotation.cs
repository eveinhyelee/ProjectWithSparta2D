using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;
    [SerializeField] private SpriteRenderer characterRenderer;

    private TopDownController controller;

    void Awake()
    {
        controller = GetComponent<TopDownController>();
    }

    void Start()
    {
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        RotateArm(direction);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //Mathf.Rad2Deg=라디안을 디그리로 바꿔라

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;// 절대값이 90도 보다 크면 Flip
        armRenderer.flipY = characterRenderer.flipX; // enemy Weapon을 뒤집어주기 위함<상하대칭이 아니어서>
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    void Update()
    {
        
    }
}
