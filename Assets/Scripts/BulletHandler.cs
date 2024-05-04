using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [SerializeField] private float speed ;
    void Update()
    {
        transform.Translate(1 * speed * Time.deltaTime, 0, 0); 
    }
}
