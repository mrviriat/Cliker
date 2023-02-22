using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public class OnPointerDownExplode : MonoBehaviour, IPointerDownHandler// required interface when using the OnPointerDown method.
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _particles;
    [SerializeField] private AudioSource _audio;

    Random rnd = new Random();
    //Do this when the mouse is clicked over the selectable object this script is attached to.
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Pressed"))
        {
            _animator.Play("Pressed", 0, 0.5f);
        }
        else
        {
            _animator.Play("Pressed");
            
        }
        PlaySound();
        PlayParticles();
        Game.singleton.OnClickButton();
    }

    public void PlaySound()
    {
        _audio.Play();
    }

    public void PlayParticles()
    {
        Instantiate(_particles, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
