using System.Xml.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "Scriptable Objects/New Shop Item", order = 1)]
public class SkinImage : ScriptableObject
{
    [SerializeField] private string _skinName;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _cost;
    [SerializeField] private bool _isBuy;

    public Sprite Sprite { get => _sprite; }
    public float Cost { get => _cost;}   
    public bool IsBuy { get =>_isBuy; }  
    public void Get()
    {
        _isBuy = true;
    }
    public void Load(bool flag)
    {
        _isBuy = flag;
    }

}
