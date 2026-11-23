using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    //GameManager에서 점수를 세고 있음
    //UIManager를 통해서 UI_Score 그 점수를 전달할거임
    //유아이스코어는 자식에 있는 유아스코어텍스트의 텍스트를 스토어 : 10 이런식으로 바꿔주면 됨

    private UI_Score_Text textScore = null;

    private Text text = null;
    
    
    private void Awake()
    {
        textScore = GetComponentInChildren<UI_Score_Text>();
    }
    public void UpdateScore(int score)
    {
        //textScore.SetText($"Score : {score}");

    }
    public void SetText(string message)
    {
        text.text = message;
    }
}
