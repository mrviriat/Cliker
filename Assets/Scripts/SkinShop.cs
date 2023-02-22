using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class SkinShop : MonoBehaviour
{
    [SerializeField] private SkinPanel[] _myPanel;

    public delegate void onBuyNewSkin(Sprite _newSkin);
    public static event onBuyNewSkin buySkin;

    public void Buy(int index)
    {
        if (Game.singleton.MyGame.Score >= _myPanel[index].MySkin.Cost)
        {
            Game.singleton.MyGame.Score -= _myPanel[index].MySkin.Cost;
            _myPanel[index].MySkin.Get();
            _myPanel[index].MakeChangeble();
        }
    }
    public void ChangeSkin()
    {
        var index = Array.IndexOf(_myPanel, EventSystem.current.currentSelectedGameObject.transform.parent.GetComponent<SkinPanel>());
        if (_myPanel[index].MySkin.IsBuy)
        {
            buySkin?.Invoke(_myPanel[index].MySkin.Sprite);
        }
        else
        {
            Buy(index);
        }
    }
    public void ExitShop()
    {
        //foreach (var panel in _myPanel)
        //{
        //    panel.Save();
        //}
    }
}

