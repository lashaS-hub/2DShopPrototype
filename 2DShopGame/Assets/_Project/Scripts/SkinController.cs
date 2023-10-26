using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    [SerializeField] private Transform _hatTransform;
    [SerializeField] private Transform _outfitTransform;

    private Animator _hatAnimator;
    private SpriteRenderer _hatSpriterenderer;
    private Animator _outfitAnimator;
    private SpriteRenderer _outfitSpriterenderer;

    public GameObject Hat { get; private set; }
    public GameObject Outfit { get; private set; }

    public void SetHat(GameObject hatPrefab)
    {
        Hat = Instantiate(hatPrefab, Vector2.zero, Quaternion.identity, _hatTransform);
        _hatAnimator = Hat.GetComponent<Animator>();
        _hatSpriterenderer = Hat.GetComponent<SpriteRenderer>();
    }

    public void SetOutfit(GameObject outfitPrefab)
    {
        Outfit = Instantiate(outfitPrefab, Vector2.zero, Quaternion.identity, _outfitTransform);
        _outfitAnimator = Outfit.GetComponent<Animator>();
        _outfitSpriterenderer = Outfit.GetComponent<SpriteRenderer>();
    }

    public void RemoveHat()
    {
        Destroy(Hat);
        _hatAnimator = null;
        _hatSpriterenderer = null;
    }

    public void RemoveOutfit()
    {
        Destroy(Outfit);
        _outfitAnimator = null;
        _outfitSpriterenderer = null;
    }

    public void SetAnimatorValues(Vector2 moveDirection)
    {
        if (_hatAnimator?.runtimeAnimatorController != null)
        {
            _hatAnimator.SetFloat("Horizontal", moveDirection.x);
            _hatAnimator.SetFloat("Vertical", moveDirection.y);
            _hatAnimator.SetFloat("Speed", moveDirection.sqrMagnitude);
        }

        if (_hatAnimator?.runtimeAnimatorController != null)
        {
            _outfitAnimator.SetFloat("Horizontal", moveDirection.x);
            _outfitAnimator.SetFloat("Vertical", moveDirection.y);
            _outfitAnimator.SetFloat("Speed", moveDirection.sqrMagnitude);
        }
    }
}
