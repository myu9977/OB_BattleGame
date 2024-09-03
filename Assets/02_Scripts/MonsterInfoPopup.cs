using UnityEngine;
using UnityEngine.UI;

public class MonsterInfoPopup : MonoBehaviour
{
    public GameObject popupPanel;
    public Text infoText;

    private void Start()
    {
        popupPanel.SetActive(false); // 시작 시 팝업 패널 비활성화
    }

    public void ShowPopup(string monsterName, int monsterHealth, string monsterGrade, float monsterSpeed)
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
            infoText.text = $"Name: {monsterName}\nHealth: {monsterHealth}\nGrade: {monsterGrade}\nSpeed: {monsterSpeed}";
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
