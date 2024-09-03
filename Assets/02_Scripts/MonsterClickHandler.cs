using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterClickHandler : MonoBehaviour
{
    public GameObject popupPanel; // UI �˾� �г�
    public Text infoText; // �˾��� ǥ���� �ؽ�Ʈ

    private void Start()
    {
        // Canvas�� ã�Ƽ� �� �ڽ����� InfoPanel�� ã��
        if (popupPanel == null)
        {
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                popupPanel = canvas.transform.Find("InfoPanel").gameObject;
            }
        }

        // InfoPanel ������ InfoText�� ã��
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
