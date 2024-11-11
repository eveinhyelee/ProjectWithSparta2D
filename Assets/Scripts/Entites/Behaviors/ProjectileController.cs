using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;
    
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer trailRenderer;

    private RangedAttackSO attackData;
    private float currentDuration;
    private Vector2 direction;
    private bool isReady;
    private bool fxOnDestroy = true;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
    }
    
    void Update()
    {
        if (!isReady)
        {
            return;
        }

        currentDuration += Time.deltaTime;
        
        if (currentDuration > attackData.duration)
        {
            DestroyProjectile(transform.position, false); //화살쏜지 오래됐으면 삭제
        }

        rigidbody.velocity = direction * attackData.speed; //스피드추가
    }

    public void InitializeAttack(Vector2 direction, RangedAttackSO attackData)
    {
        this.attackData = attackData;
        this.direction = direction;

        UpdateProjectileSprite();
        trailRenderer.Clear();
        currentDuration = 0;
        spriteRenderer.color = attackData.projectileColor;

        transform.right = this.direction;

        isReady = true;
    }

    private void DestroyProjectile(Vector3 position, bool createFx)
    {
        if (createFx)
        {
            //TODO: PartiacleSystem에 대해서 배우고, 무기 NameTag로 해당하는 FX가져오기
        }
        gameObject.SetActive(false);
    }

    private void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * attackData.size;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsLayerMatChed(levelCollisionLayer.value, collision.gameObject.layer))
        {
            Vector2 destroyPosition = collision.ClosestPoint(transform.position) - direction * 0.2f;
            DestroyProjectile(destroyPosition, fxOnDestroy);
        }
        else if(IsLayerMatChed(attackData.target.value, collision.gameObject.layer))
        {
            //TODO : 데미지를 준다 fxOnDestroy = bool값
            DestroyProjectile(collision.ClosestPoint(transform.position),fxOnDestroy);
        }
    }

    private bool IsLayerMatChed(int value, int layer) //다른 레이어가 들어왔는지 확인하는 함수
    {
        return value == (value | 1 << layer);
    }
}

