using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSettingUI : MonoBehaviour
{
    public GameObject target;
    

    public void OnSettingButtonClick()
    {
        if (target.activeSelf == false)
            target.SetActive(true);
        else
            target.SetActive(false);
    }
}
