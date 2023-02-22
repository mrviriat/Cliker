using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public void ElementSetActive(GameObject gameobject)
    {
        if (gameObject.GetComponent<Animator>())
        {
            if (!gameobject.activeSelf)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Start");
                return;
            }
            gameObject.GetComponent<Animator>().SetTrigger("End");
            return;
        }
        gameobject.SetActive(!gameobject.activeSelf);
    }
}
