using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterClickHandler : MonoBehaviour
{
    public GameObject popupPanel; // UI 팝업 패널
    public Text infoText; // 팝업에 표시할 텍스트

    private void Start()
    {
        // Canvas를 찾아서 그 자식으로 InfoPanel을 찾음
        if (popupPanel == null)
        {
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                popupPanel = canvas.transform.Find("InfoPanel").gameObject;
            }
        }

        // InfoPanel 내에서 InfoText를 찾음
        if (infoText == null && popupPanel != null)
        {
            Transform infoTextTransform = popupPanel.transform.Find("InfoText");
            if (infoTextTransform != null)
            {
                infoText = infoTextTransform.GetComponent<Text>();
            }
        }
    }

    private void OnMouseDown()
    {
        ShowPopup();
    }

    void ShowPopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
            infoText.text = $"Name: {gameObject.name}\nHealth: {GetComponent<MonsterHealth>().health}";
        }
    }
}
