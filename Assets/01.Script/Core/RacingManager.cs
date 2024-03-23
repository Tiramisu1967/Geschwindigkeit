using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RacingManager : MonoBehaviour
{
    public Canvas HelpCnavas;
    public Canvas RackingCnavas;
    public Canvas MainCanvas;

    private List<RankingEntry> rankingEntries = new List<RankingEntry>();
    public TextMeshProUGUI[] Rankings = new TextMeshProUGUI[5];

    private string CurrentPlayerInitial;

    public void Start()
    {

        SetCurrentScore();
        SortRanking();
        UpdateRankingUI();
    }
    public void MainMenuRanking()
    {
        RackingCnavas.gameObject.SetActive(true);
        MainCanvas.gameObject.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            float currentScore = PlayerPrefs.GetFloat(i + "BestScore");

            rankingEntries.Add(new RankingEntry(currentScore));
        }

        SortRanking();

        for (int i = 0; i < Rankings.Length; i++)
        {
            if (i < rankingEntries.Count)
            {
                Rankings[i].text = $"{i + 1}  : {rankingEntries[i].Score}";
            }
            else
            {
                Rankings[i].text = $"{i + 1} -";
            }
        }
    }

    void SetCurrentScore()
    {
        rankingEntries.Clear();
        for (int i = 0; i < 5; i++)
        {
            float currentScore = PlayerPrefs.GetFloat(i + "BestScore");

            rankingEntries.Add(new RankingEntry(currentScore));
        }

        // 현재 플레이어의 점수와 이름을 가져와 랭킹에 등록
        float currentPlayerScore = GameInstance.instance.RacingTime;
        string currentPlayerName = CurrentPlayerInitial;

        // 현재 플레이어의 점수가 랭킹에 등록 가능한지 확인
        if (IsScoreEligibleForRanking(currentPlayerScore))
        {
            rankingEntries.Add(new RankingEntry(currentPlayerScore));
        }
    }

    bool IsScoreEligibleForRanking(float currentPlayerScore)
    {
        return rankingEntries.Count < 5 || currentPlayerScore > rankingEntries.Min(entry => entry.Score);
    }

    void SortRanking()
    {
        rankingEntries = rankingEntries.OrderByDescending(entry => entry.Score).ToList();

        if (rankingEntries.Count > 5)
        {
            rankingEntries.RemoveAt(rankingEntries.Count - 1);
        }
    }

    void UpdateRankingUI()
    {
        for (int i = 0; i < Rankings.Length; i++)
        {
            if (i < rankingEntries.Count)
            {
                Rankings[i].text = $"{i + 1}  : {rankingEntries[i].Score}";
            }
            else
            {
                Rankings[i].text = $"{i + 1} -";
            }
        }


        for (int i = 0; i < rankingEntries.Count; i++)
        {
            PlayerPrefs.SetFloat(i + "BestScore", rankingEntries[i].Score);
        }
    }

public void GameStart()
    {
        if(GameInstance.instance != null)
        {
            GameInstance.instance.Coin = 0;
            GameInstance.instance.CurrentWayPointCount = 0;
            GameInstance.instance.LabCount = 0;
            GameInstance.instance.RacingTime = 0;
            GameInstance.instance.RacingTime = 0;
            GameInstance.instance.Stage = 1;
            GameInstance.instance._IsTurn = false;
        }
        SceneManager.LoadScene("Stage1");
    }
    
    public void MainMenu()
    {
        RackingCnavas.gameObject.SetActive(false);
        MainCanvas.gameObject.SetActive(true);
    }

    public void HelpBox()
    {
        HelpCnavas.gameObject.SetActive(true);
    }
}
public class RankingEntry
{
    public float Score { get; set; }

    public RankingEntry(float score)
    {
        Score = score;
    }
}