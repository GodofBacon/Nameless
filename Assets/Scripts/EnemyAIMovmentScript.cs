using UnityEngine;
using System.Collections;

public class EnemyAIMovmentScript : MonoBehaviour
{

    public Transform Target;
    private GameObject Enemy;
    private GameObject Player;
    private float Range;
    public float Speed;


    
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        Range = Vector2.Distance(Enemy.transform.position, Player.transform.position);
        if (Range <= 15f)
        {
            transform.Translate(Vector2.MoveTowards(Enemy.transform.position, Player.transform.position, Range) * Speed * Time.deltaTime);
        }
    }
}