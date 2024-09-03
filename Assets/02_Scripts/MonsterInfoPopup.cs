using UnityEngine;
using UnityEngine.UI;

public class MonsterInfoPopup : MonoBehaviour
{
    public GameObject popupPanel;
    public Text infoText;

    private void Start()
    {
        popupPanel.SetActive(false); // ���� �� �˾� �г� ��Ȱ��ȭ
    }

    public void ShowPopup(string monsterName, int monsterHealth)
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
            infoText.text = $"Name: {monsterName}\nHealth: {monsterHealth}";
        }
    }

    public void ClosePopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
        }
    }
}
