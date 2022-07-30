using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicTowerButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        EmtpyTowerSpace parent = GetComponentInParent<EmtpyTowerSpace>();

        Transform transform = Instantiate<Transform>(GameAssets.i.ClassicTower, parent.transform.position, Quaternion.identity);
        TowerClassic towerClassic = transform.GetComponent<TowerClassic>();
        towerClassic.transform.position = parent.gameObject.transform.position;

        parent.Desactivate();
    }
}
