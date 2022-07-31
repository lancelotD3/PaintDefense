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

    [SerializeField]
    private int life = 20;

    [SerializeField]
    private int golds = 100;



    // Start is called before the first frame update
    void Start()
    {
        EnemyManager.Create("BigEnemy", startingPos.position, wayPoints);
        EnemyManager.Create("BigEnemy", startingPos.position, wayPoints);
        EnemyManager.Create("BigEnemy", startingPos.position, wayPoints);
        EnemyManager.Create("BigEnemy", startingPos.position, wayPoints);
        EnemyManager.Create("ClassicEnemy", startingPos.position, wayPoints);
        EnemyManager.Create("ClassicEnemy", startingPos.position, wayPoints);
        EnemyManager.Create("ClassicEnemy", startingPos.position, wayPoints);
        EnemyManager.Create("ClassicEnemy", startingPos.position, wayPoints);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if(!enemy.finishedLevel)
            {
                life -= enemy.GetDamageOnGeneralLife();
                enemy.finishedLevel = true;
            }
        }
    }

    public string GetLifeText() {return life.ToString();}

    // Money system
    #region Money system
    public int GetGolds() => golds;
    public string GetGoldsText() {return golds.ToString();}
    public void RemoveGolds(int value)
    {
        golds -= value;
    }

    public void AddGolds(int value)
    {
        golds += value;
    }

    #endregion



}
