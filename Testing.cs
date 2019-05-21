using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Testing : MonoBehaviour
{
    public Setting setting;

    public bool isSetting;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        isSetting = false;
    }

    public void OnSettingButtonClick()
    {
        if (isSetting)
        {
            isSetting = false;
        }
        else
            isSetting = true;
       
    }


    // Update is called once per frame
    void Update()
    {
        if(!isSetting)
        {
            if (Input.GetKey(setting.LeftKey))
            {
                transform.position = transform.position + new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(setting.RightKey))
            {
                transform.position = transform.position + new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(setting.DownKey))
            {
                transform.position = transform.position + new Vector3(0, -moveSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey(setting.UpKey))
            {
                transform.position = transform.position + new Vector3(0, moveSpeed * Time.deltaTime, 0);
            }
        }
        
    }
}

[CreateAssetMenu]
[System.Serializable]
public class Setting:ScriptableObject
{

    public KeyCode UpKey;

    public KeyCode LeftKey;

    public KeyCode RightKey;

    public KeyCode DownKey;
}