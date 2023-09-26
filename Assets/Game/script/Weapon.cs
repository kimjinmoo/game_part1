using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public int id;
    public int prefabId;
    public float damage;

    private void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init() {
        switch(id) {
            case 0:
                break;
            default:
                break;
        }
    } 
}
