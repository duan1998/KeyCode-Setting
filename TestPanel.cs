using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPanel : MonoBehaviour
{

    public Button keyUpButton;
    public Image keyUpSelectedBgImage;
    public Text keyUpText;
    public Text keyUpSurfaceText;

    [Space(10)]
    public Button keyLeftButton;
    public Image keyLeftSelectedBgImage;
    public Text keyLeftText;
    public Text keyLeftSurfaceText;

    [Space(10)]
    public Button keyRightButton;
    public Image keyRightSelectedBgImage;
    public Text keyRightText;
    public Text keyRightSurfaceText;

    [Space(10)]
    public Button keyDownButton;
    public Image keyDownSelectedBgImage;
    public Text keyDownText;
    public Text keyDownSurfaceText;

    
    private Button currentSelectedButton;
    private Image currentSelectedImageBg;
    private Text currentSelectedText;
    private Text currentSelectedSurfaceText;

    [Space(10)]
    public Setting setting;

    private bool isSelected;



    private void OnEnable()
    {
        ClearTmpState();
    }
    private void Start()
    {
        //加载

        keyUpText.text = setting.UpKey.ToString();
        keyLeftText.text = setting.LeftKey.ToString();
        keyRightText.text = setting.RightKey.ToString();
        keyDownText.text = setting.DownKey.ToString();




        keyUpButton.onClick.AddListener(() => OnButtonClick(keyUpButton, keyUpSelectedBgImage, keyUpText, keyUpSurfaceText));
        keyLeftButton.onClick.AddListener(() => OnButtonClick(keyLeftButton, keyLeftSelectedBgImage, keyLeftText, keyLeftSurfaceText));
        keyRightButton.onClick.AddListener(() => OnButtonClick(keyRightButton, keyRightSelectedBgImage, keyRightText, keyRightSurfaceText));
        keyDownButton.onClick.AddListener(() => OnButtonClick(keyDownButton, keyDownSelectedBgImage, keyDownText, keyDownSurfaceText));

        isSelected = false;
    }

    public void OnButtonClick(Button button,Image imageBg,Text text,Text surfaceText)
    {
        if(currentSelectedButton==button)
        {
            return;
        }
        if(currentSelectedButton!=null)
        {
            currentSelectedImageBg.color= new Color(imageBg.color.r, imageBg.color.g, imageBg.color.b, 0);
            if(currentSelectedSurfaceText.text!="????")
            {
                currentSelectedText.text = currentSelectedSurfaceText.text;
                currentSelectedSurfaceText.text = "????";
            }
            currentSelectedSurfaceText.enabled = false;
            currentSelectedText.enabled = true;
            ClearTmpState();
        }
        imageBg.color = new Color(imageBg.color.r, imageBg.color.g, imageBg.color.b, 1);
        surfaceText.enabled = true;
        text.enabled = false;

        currentSelectedButton = button;
        currentSelectedImageBg = imageBg;
        currentSelectedText = text;
        currentSelectedSurfaceText = surfaceText;

        isSelected = true;

    }


    public void OnSaveButtonClick()
    {



        if(currentSelectedText!=null)
        {
            currentSelectedText.text = currentSelectedSurfaceText.text;
            currentSelectedSurfaceText.text = "????";
            currentSelectedText.enabled = true;
            currentSelectedSurfaceText.enabled = false;
            currentSelectedImageBg.color = new Color(currentSelectedImageBg.color.r, currentSelectedImageBg.color.g, currentSelectedImageBg.color.b, 0);
        }
        setting.UpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyUpText.text);
        setting.LeftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyLeftText.text);
        setting.RightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyRightText.text);
        setting.DownKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyDownText.text);


        this.gameObject.SetActive(false);

    }

    private void OnGUI()
    {
        if (isSelected)
        {
            if (Input.anyKeyDown)
            {
                if(Event.current.keyCode!=KeyCode.None)
                    currentSelectedSurfaceText.text = Event.current.keyCode.ToString();
            }
        }
    }

    private void OnDisable()
    {
        ClearTmpState();
        isSelected = false;
    }

    private void ClearTmpState()
    {
        currentSelectedButton = null;
        currentSelectedImageBg = null;
        currentSelectedText = null;
        currentSelectedSurfaceText = null;
    }

}
