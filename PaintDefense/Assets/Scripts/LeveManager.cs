using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
using Helpers.Utils;

public class LeveManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoints;

    [SerializeField]
    private Transform startingPos;


    int life = 20;

    // Start is called before the first frame update
    void Start()
    {
        EnemyManager.Create("BigEnemy", startingPos.position, wayPoints);
        EnemyManager.Create("ClassicEnemy", startingPos.position, wayPoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            life -= enemy.GetDamageOnGeneralLife();
            Debug.Log(life);
        }
        
    }
}
