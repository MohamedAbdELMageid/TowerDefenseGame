using System.Collections.Generic;
using UnityEngine;


public class EnemyMover : MonoBehaviour
{
    public int health;
    [SerializeField] List<Transform> targets;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject winMenu;
    [SerializeField] float speed;
    Transform m_Transform;
    Animator m_Animator;
    int direction;
    private void Start()
    {
        direction = 0;
        m_Animator = GetComponent<Animator>();
        m_Transform = GetComponent<Transform>();
    }
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            LevelManager.aliveEnemyCount--;
            if(LevelManager.aliveEnemyCount == 0)
            {
                SoundManager.Instance.PlaySfx("Winning");
                Time.timeScale = 0;
                winMenu.SetActive(true);
            }
        }
        if(targets.Count > 0) m_Transform.position = Vector3.MoveTowards(m_Transform.position, targets[0].position, Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Target"))
        {
            if (targets != null && targets.Count > 0) 
            {
                targets.RemoveAt(0);
                if (targets.Count > 0)
                {
                    if (targets[0].position.x - m_Transform.position.x < Mathf.Abs(targets[0].position.y - m_Transform.position.y))
                    {
                        if (targets[0].position.y > m_Transform.position.y)
                        {
                            direction = 1;
                        }
                        else
                        {
                            direction = -1;
                        }
                    }
                    else
                    {
                        direction = 0;
                    }
                    m_Animator.SetInteger("State", direction);
                }
            }
              
            
        }
        if (collision.gameObject.CompareTag("End"))
        {
            gameOver.SetActive(true);
            SoundManager.Instance.PlaySfx("GameOver");
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
    
}
