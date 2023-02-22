using System;
public class Logic
{
    public float Score;
    public float ClickScore = 1;
    public float[] CostBonus = new float[5] { 0, 0, 0, 0, 0 };
    public float[] CostInt = new float[10] { 100, 1000, 10000, 100000, 1000000, 100, 1000, 100000, 1000000, 100000000 };

    public int Achievement1Max = 0;

    public bool isAcievement1 = true;
    public bool isAcievement2 = true;
    public bool isAchievement2Get = false;
    public bool isAcievement3 = true;
    public bool isAchievement3Get = false;

    public bool[] ButtonStan = new bool[3]
        {true, true, true};

    public Logic()
    {
    }
}
