using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Sprite MySkin;

    void Start()
    {
        SkinShop.buySkin += ChangeSKin;
        if (PlayerPrefs.HasKey("MySkin"))
        {
            MySkin = Resources.Load<Sprite>("Sprites/" + PlayerPrefs.GetString("MySkin"));
            gameObject.GetComponent<Image>().sprite = MySkin;
        }
    }
    private void ChangeSKin(Sprite _newSprine)
    {
        gameObject.GetComponent<Image>().sprite = _newSprine;
    }

#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("MySkin", gameObject.GetComponent<Image>().sprite.name);
    }
#endif

#if UNITY_ANDROID
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            PlayerPrefs.SetString("MySkin", gameObject.GetComponent<Image>().sprite.name);
        }
    }
#endif
}
