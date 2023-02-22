using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml.Serialization;
using Unity.VisualScripting;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;

public class Game : MonoBehaviour
{
    public Logic MyGame;

    public Text[] CostText;
    public Text ScoreText;

    public Text[] AchievementsText;
    public Text[] AchievementsCost;
    public Text Achievement1NameText;
    public Button[] AchievementButtons;
    public static Game singleton { get; private set; }


    private void Start()
    {

        Load();
        AchievementButtons[0].enabled = MyGame.ButtonStan[0];
        AchievementButtons[1].enabled = MyGame.ButtonStan[1];
        AchievementButtons[2].enabled = MyGame.ButtonStan[2];
        StartCoroutine(BonusShop());
    }
    public delegate void onClick(float Count);
    public event onClick ClickAction;

    void Awake()
    {
        singleton = this;
        
    }
    void Save()
    {
        PlayerPrefs.SetString("Save", Helper.Serialize<Logic>(MyGame));
    }
    void Load()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            MyGame = Helper.Deserialize<Logic>(PlayerPrefs.GetString("Save"));
        }
        else
        {
            MyGame = new Logic();
            Save();
        }
        MyGame = new Logic();
    }
    public void ScoreChange()
    {
        ScoreText.text = MyGame.Score + "$";
        Achievement1NameText.text = "кликов " + MyGame.Achievement1Max + "/500";
    }

    public void OnClickButton()
    {
        MyGame.Score += MyGame.ClickScore;
        if (MyGame.isAcievement1 == true && MyGame.Achievement1Max < 500)
        {
            MyGame.Achievement1Max++;
        }
        ClickAction?.Invoke(MyGame.Score);
    }

    public void Cheat(InputField inputfield)
    {
        if (inputfield.text == "RTDMaklerPro1337")
        {
            MyGame.Score += 25;
        }
        if (inputfield.text == "1000")
        {
            MyGame.Score += 1000;
        }
        inputfield.text = "";
    }


    private void Update()
    {
        ScoreChange();
        if (MyGame.isAcievement1 == false)
        {
            AchievementsCost[0].text = "Выполнено";
        }

        if (MyGame.Achievement1Max >= 500)
        {
            AchievementsText[0].text = "Выполнено";
        }

        if (MyGame.isAchievement2Get == true)
        {
            AchievementsCost[1].text = "Выполнено";
        }

        if (MyGame.isAcievement2 == false)
        {
            AchievementsText[1].text = "Выполнено";
        }

        if (MyGame.isAchievement3Get == true)
        {
            AchievementsCost[2].text = "Выполнено";
        }

        if (MyGame.isAcievement3 == false)
        {
            AchievementsText[2].text = "Выполнено";
        }

        ScoreText.text = ReductionNum._ReductionNum(MyGame.Score) + "$";

        for (int i = 0; i < CostText.Length; i++)
        {
            CostText[i].text = ReductionNum._ReductionNum(MyGame.CostInt[i]) + "$";
        }
        AchievementButtons[0].enabled = MyGame.ButtonStan[0];
        AchievementButtons[1].enabled = MyGame.ButtonStan[1];
        AchievementButtons[2].enabled = MyGame.ButtonStan[2];


    }

    //Dictionary<int, float[]> bonuses = new Dictionary<int, float[]>()
    //{
    //    { 0, new float[] { 1, 2, 3, 5 } },
    //    { 1, new float[] { 1, 2, 3, 5 }},
    //    { 2, new float[] { 1, 2, 3, 5 }},
    //    { 3, new float[] { 1, 2, 3, 5 }},
    //    { 4, new float[] { 1, 2, 3, 5 }}
    //};
    //public void OnClickBuyLeve(int index, float high, float bonus)
    //{
    //    if (MyGame.Score >= MyGame.CostInt[index])
    //    {
    //        Score -= CostInt[index];
    //        CostInt[0] *= high;//???? ????????????? ? * ???
    //        ClickScore += bonus;//????????? ????? ????????????? ?? 1
    //        CostText[0].text = CostInt[0] + "$";
    //        isAcievement2 = false;
    //    }
    //}

    public void OnClickBuyLevel()
    {
        if (MyGame.Score >= MyGame.CostInt[0])
        {
            MyGame.Score -= MyGame.CostInt[0];
            MyGame.CostInt[0] *= 2;
            MyGame.ClickScore += 1;
            CostText[0].text = MyGame.CostInt[0] + "$";
            MyGame.isAcievement2 = false;
        }
    }

    public void OnClickBuyLevel2()
    {
        if (MyGame.Score >= MyGame.CostInt[1])
        {
            MyGame.Score -= MyGame.CostInt[1];
            MyGame.CostInt[1] *= 2.5F;
            MyGame.ClickScore += 2;
            CostText[1].text = MyGame.CostInt[1] + "$";
            MyGame.isAcievement2 = false;
        }
    }

    public void OnClickBuyLevel3()
    {
        if (MyGame.Score >= MyGame.CostInt[2])
        {
            MyGame.Score -= MyGame.CostInt[2];
            MyGame.CostInt[2] *= 3;
            MyGame.ClickScore += 4;
            CostText[2].text = MyGame.CostInt[2] + "$";
            MyGame.isAcievement2 = false;
        }
    }
    public void OnClickBuyLevel4()
    {
        if (MyGame.Score >= MyGame.CostInt[3])
        {
            MyGame.Score -= MyGame.CostInt[3];
            MyGame.CostInt[3] *= 3;
            MyGame.ClickScore *= 2;
            CostText[3].text = MyGame.CostInt[3] + "$";
            MyGame.isAcievement2 = false;
        }
    }
    public void OnClickBuyLevel5()
    {
        if (MyGame.Score >= MyGame.CostInt[4])
        {
            MyGame.Score -= MyGame.CostInt[4];
            MyGame.CostInt[4] *= 5;
            MyGame.ClickScore *= 5;
            CostText[4].text = MyGame.CostInt[4] + "$";
            MyGame.isAcievement2 = false;
        }
    }

    public void ReserClick()  //кнопка сброса
    {

        MyGame.ClickScore = 1;
        MyGame.Score = 0;

        MyGame.CostInt[0] = 100;
        MyGame.CostInt[1] = 1000;
        MyGame.CostInt[2] = 10000;
        MyGame.CostInt[3] = 100000;
        MyGame.CostInt[4] = 1000000;
        MyGame.CostInt[5] = 100;
        MyGame.CostInt[6] = 1000;
        MyGame.CostInt[7] = 100000;
        MyGame.CostInt[8] = 1000000;
        MyGame.CostInt[9] = 100000000;
        MyGame.CostBonus[0] = 0;
        MyGame.CostBonus[1] = 0;
        MyGame.CostBonus[3] = 0;
        MyGame.CostBonus[4] = 0;
    }

    public void OnClickBuyBonusShop()
    {
        if (MyGame.Score >= MyGame.CostInt[5])
        {
            MyGame.Score -= MyGame.CostInt[5];
            MyGame.CostInt[5] *= 10;
            MyGame.CostBonus[0] += 1;
            CostText[5].text = MyGame.CostInt[5] + "$";
            MyGame.isAcievement3 = false;
        }
    }
    public void OnClickBuyBonusShop1()
    {
        if (MyGame.Score >= MyGame.CostInt[6])
        {
            MyGame.Score -= MyGame.CostInt[6];
            MyGame.CostInt[6] *= 5;
            MyGame.CostBonus[1] += 2;
            CostText[6].text = MyGame.CostInt[6] + "$";
            MyGame.isAcievement3 = false;
        }
    }
    public void OnClickBuyBonusShop2()
    {
        if (MyGame.Score >= MyGame.CostInt[7])
        {
            MyGame.Score -= MyGame.CostInt[7];
            MyGame.CostInt[7] *= 3;
            MyGame.CostBonus[2] += 5;
            CostText[7].text = MyGame.CostInt[7] + "$";
            MyGame.isAcievement3 = false;
        }
    }
    public void OnClickBuyBonusShop3()
    {
        if (MyGame.Score >= MyGame.CostInt[8])
        {
            MyGame.Score -= MyGame.CostInt[8];
            MyGame.CostInt[8] *= 2;
            MyGame.CostBonus[3] += 50;
            CostText[8].text = MyGame.CostInt[8] + "$";
            MyGame.isAcievement3 = false;
        }
    }
    public void OnClickBuyBonusShop4()
    {
        if (MyGame.Score >= MyGame.CostInt[9])
        {
            MyGame.Score -= MyGame.CostInt[9];
            MyGame.CostInt[9] *= 1.5F;
            MyGame.CostBonus[4] += 1000;
            CostText[9].text = MyGame.CostInt[9] + "$";
            MyGame.isAcievement3 = false;
        }
    }

    IEnumerator BonusShop()
    {
        while (true)
        {
            MyGame.Score += MyGame.CostBonus[0];
            MyGame.Score += MyGame.CostBonus[1];
            MyGame.Score += MyGame.CostBonus[2];
            MyGame.Score += MyGame.CostBonus[3];
            MyGame.Score += MyGame.CostBonus[4];
            yield return new WaitForSeconds(1);
        }
    }
    public void OnClickAchievement1Button()
    {
        if (MyGame.isAcievement1 == true && MyGame.Achievement1Max >= 500)
        {
            MyGame.ButtonStan[0] = false;
            MyGame.Score += 500;
            MyGame.isAcievement1 = false;
        }
    }

    public void OnClickAchievement2Button()
    {
        if (MyGame.isAcievement2 == false)
        {
            MyGame.ButtonStan[1] = false;
            MyGame.Score += 30;
            MyGame.isAcievement2 = false;
            MyGame.isAchievement2Get = true;
        }
    }

    public void OnClickAchievement3Button()
    {
        if (MyGame.isAcievement3 == false)
        {
            MyGame.ButtonStan[2] = false;
            MyGame.Score += 60;
            MyGame.isAcievement3 = false;
            MyGame.isAchievement3Get = true;
        }
    }

#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        Save();
    }
#endif

#if UNITY_ANDROID
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }
#endif

}


