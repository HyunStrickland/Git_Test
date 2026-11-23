using UnityEngine;

public class UIManager : MonoBehaviour
{
    private UI_Score uiScore = null;
    private UI_GameClear uiGameClear = null;
    private UI_GameOver uiGameOver = null;
    private UI_Title uiTitle = null;    

    private void Awake()
    {
        uiScore = GetComponentInChildren<UI_Score>();
        uiGameClear = GetComponentInChildren<UI_GameClear>();
        uiGameOver = GetComponentInChildren<UI_GameOver>();
    }
    public void Init()
    {
        uiGameOver.gameObject.SetActive(false);
        uiGameClear.gameObject.SetActive(false);
    }
    public void UpdateScoreUI(int score)
    {
        uiScore.UpdateScore(score);
    }
    public void ShowGameOverUI()
    {
        uiGameOver.gameObject.SetActive(true);
    }
    public void ShowGameClearUI()
    {
        uiGameClear.gameObject.SetActive(true);

    }
}
