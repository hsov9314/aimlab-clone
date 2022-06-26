using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    public GameObject ammoTextUI;
    public TextMeshProUGUI tmp;
    public int pistolCount;

    //public void getPistolCount()
    //{
    //    return getPistolCount;
    //}

    //public void setPistolCount(int count)
    //{
    //    pistolCount = count;
    //}


    // Update is called once per frame
    void Update()
    {
        tmp.text = "ammo: " + pistolCount;
    }
}
