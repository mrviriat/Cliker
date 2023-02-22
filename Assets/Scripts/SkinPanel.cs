using System;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

public class SkinPanel : MonoBehaviour
{
    [SerializeField] private SkinImage _mySkin;
    [SerializeField] private Text _buttonText;
    [SerializeField] private Text _cost;
    [SerializeField] private Image _skinImage;
    public SkinImage MySkin { get => _mySkin; } 
    private void Start()
    {
        //if (PlayerPrefs.HasKey(_mySkin.name))
        //{
        //    _mySkin.Load(Helper.intToBool(PlayerPrefs.GetInt(_mySkin.name)));
        //}
        if (!_mySkin.IsBuy)
        {
            _buttonText.text = "Купить";
        }
        else
        {
            MakeChangeble();
        }
        _cost.text = _mySkin.Cost.ToString();
        _skinImage.sprite = _mySkin.Sprite;
    }
    public void MakeChangeble()
    {
        _buttonText.text = "Change Skin";
    }
    public void Save()
    {
        PlayerPrefs.SetInt(_mySkin.name, Helper.boolToInt(_mySkin.IsBuy));
    }
//#if UNITY_EDITOR
//    private void OnApplicationQuit()
//    {
//        Save();
//    }
//#endif

//#if UNITY_ANDROID
//    void OnApplicationPause(bool pauseStatus)
//    {
//        if (pauseStatus)
//        {
//            Save();
//        }
//    }
//#endif
}
