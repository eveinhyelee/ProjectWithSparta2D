using System;
using UnityEngine;

public class TopDownShoothng : MonoBehaviour
{
    private TopDownController controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 aimDirection = Vector2.right;
    public GameObject TestPrefab;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
    }
    private void Start()
    {
        controller.OnAttackEvent += OnShoot;
        controller.OnLookEvent += OnAim;

    }

    private void OnAim(Vector2 direction)
    {
        aimDirection = direction; // 마우스 움직일때마다 바꿔줌
    }

    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        //TODO :: 날라가질 않기 때문에 날라가게 만들것임
        Instantiate(TestPrefab, projectileSpawnPosition.position, Quaternion.identity);
    }
}
