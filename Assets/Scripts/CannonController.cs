using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class CannonController : MonoBehaviour
{
    [SerializeField] List<Transform> enemies;
    [SerializeField] List<GameObject> bullets;
    [SerializeField] Sprite idle;
    float timer;
    Animator animator;
    void Start()
    {
        timer = 0;
        enemies = new List<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Count > 0)
        {
            timer += Time.deltaTime;
            if(timer > 0.5)
            {
                foreach(var bullet in bullets)
                {
                    GameObject b = Instantiate(bullet);
                    b.SetActive(true);
                    b.transform.position = bullet.transform.position;
                    b.transform.rotation = bullet.transform.rotation;
                }
                timer = 0;
            }
            animator.enabled = true;
            Vector2 direction = enemies[0].position - transform.position;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
            // transform.LookAt(enemies[0]);
        }
        else
        {
            animator.enabled = false;
            GetComponent<SpriteRenderer>().sprite = idle;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemies.Add(collision.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemies.Remove(collision.transform);
        }
    }
}
