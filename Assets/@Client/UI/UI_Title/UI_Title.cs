using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UI_Title : MonoBehaviour
{
    private UI_Title_Button_GameStart buttonGamestart = null;

    private void Awake()
    {
        buttonGamestart = GetComponentInChildren<UI_Title_Button_GameStart>();
    }
    private void Start()
    {
        SetButtonEvent();
    }
    private void SetButtonEvent()
    {
        buttonGamestart.SetEvent(ChangeScene);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
