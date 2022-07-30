using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTowerButton : MonoBehaviour
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

        Transform transform = Instantiate<Transform>(GameAssets.i.BigTower, parent.transform.position, Quaternion.identity);
        BigTower bigClassic = transform.GetComponent<BigTower>();
        bigClassic.transform.position = parent.gameObject.transform.position;

        parent.Desactivate();
    }
}
