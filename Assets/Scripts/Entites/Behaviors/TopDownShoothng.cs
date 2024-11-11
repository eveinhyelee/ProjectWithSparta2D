using System;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;

public class TopDownShoothng : MonoBehaviour
{
    private TopDownController controller;

    [SerializeField] private Transform projectileSpawnPosition; //총알생성위치
    private Vector2 aimDirection = Vector2.right;
    public GameObject TestPrefab;

    private ObjectPool pool; 

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        pool = GameObject.FindObjectOfType<ObjectPool>(); //TODO : 오브젝트 풀을 가져옴 - 코드바꿀예정
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

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackSO rangedAttackSO = attackSO as RangedAttackSO; //형변환시도
        if (rangedAttackSO == null) return;
        float projectilesAngleSpace = rangedAttackSO.multipleProjectilesAngle;
        int numberOfPeojectilesPerShot = rangedAttackSO.numberOfProjectilesPerShot;

        float minAngle = -(numberOfPeojectilesPerShot / 2f) * projectilesAngleSpace + 0.5f
            * rangedAttackSO.multipleProjectilesAngle;
        for (int i = 0; i < numberOfPeojectilesPerShot; i++)
        {
            float angle = minAngle + i * projectilesAngleSpace;
            float randomSpread = Random.Range(-rangedAttackSO.spread, rangedAttackSO.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackSO, angle);
        }
    }

    private void CreateProjectile(RangedAttackSO rangedAttackSO, float angle) //projectile = 투사체라는 게임 용어
    {
        GameObject obj = pool.SpawnFromPool(rangedAttackSO.bulletNameTag);//Instantiate(TestPrefab);
        obj.transform.position = projectileSpawnPosition.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController>();
        attackController.InitializeAttack(RotateVector2(aimDirection,angle),rangedAttackSO);
        
        //TODO : 날라가질 않기 때문에 날라가게 만들것임
        //Instantiate(TestPrefab, projectileSpawnPosition.position, Quaternion.identity);
    }

    private static Vector2 RotateVector2(Vector2 v, float angle)
    {
        return Quaternion.Euler(0f, 0f, angle) * v;
    }
}
