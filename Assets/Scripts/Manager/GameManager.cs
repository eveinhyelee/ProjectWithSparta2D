using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform Player { get; private set; }
    public ObjectPool ObjectPool { get; private set; } 
    
    [SerializeField] private string playerTag = "Player";

    void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;

        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
        ObjectPool = GetComponent<ObjectPool>(); //TODO : 오브젝트 풀을 가져옴 - 코드바꿀예정

    }
    
    void Update()
    {
        
    }
}
