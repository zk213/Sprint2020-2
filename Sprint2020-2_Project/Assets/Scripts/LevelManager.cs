using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int currentRound = 0;
    private static int roundStartNum = 0;
    private static int roundTypeIndex = 0;

    public List<RoundType> roundTypes = new List<RoundType>();
    public LevelChanger levelChanger;

    #region SINGLETON PATTERN
    public static LevelManager _instance;
    public static LevelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<LevelManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("LevelManager");
                    _instance = container.AddComponent<LevelManager>();
                }
            }

            return _instance;
        }
    }
    #endregion


    // Changes to the round type to the next one in the list, if there is one
    void changeRoundType(int newTypeIndex)
    {
        if (roundTypeIndex >= roundTypes.Count)
        {
            return;
        }

        roundStartNum = 0;
        roundTypeIndex = newTypeIndex;
    }

    public void goToNextRound()
    {
        currentRound++;
        roundStartNum++;
        levelChanger.FadeToLevel(1);
      

        RoundType currentRoundType = getRoundType();
        if(currentRoundType != null)
        {
            if(!currentRoundType.infiniteRounds)
            {
                if(roundStartNum >= currentRoundType.totalRounds)
                {
                    changeRoundType(roundTypeIndex + 1);
                }
            }
        }
    }

    public RoundType getRoundType()
    {
        if (roundTypeIndex >= roundTypes.Count)
        {
            return null;
        }

        return roundTypes[roundTypeIndex];
    }
}
