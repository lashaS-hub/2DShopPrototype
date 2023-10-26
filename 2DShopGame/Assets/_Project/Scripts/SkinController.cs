using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    [SerializeField] private Animator _hatAnimator;
    [SerializeField] private SpriteRenderer _hatSpriterenderer;
    [SerializeField] private Animator _outfitAnimator;
    [SerializeField] private SpriteRenderer _outfitSpriterenderer;

    public void SetHatAnimator(AnimatorController hatAnimatorController)
    {
        _hatAnimator.runtimeAnimatorController = hatAnimatorController;
    }

    public void SetOutfitAnimator(AnimatorController outfitAnimatorController)
    {
        _outfitAnimator.runtimeAnimatorController = outfitAnimatorController;
    }

    public void RemoveHat()
    {
        _hatAnimator.runtimeAnimatorController = null;
        _hatSpriterenderer.sprite = null;
    }

    public void RemoveOutfit()
    {
        _outfitAnimator.runtimeAnimatorController = null;
        _outfitSpriterenderer.sprite = null;
    }

    public void SetAnimatorValues(Vector2 moveDirection)
    {
        if (_hatAnimator.runtimeAnimatorController != null)
        {
            _hatAnimator.SetFloat("Horizontal", moveDirection.x);
            _hatAnimator.SetFloat("Vertical", moveDirection.y);
            _hatAnimator.SetFloat("Speed", moveDirection.sqrMagnitude);
        }

        if (_hatAnimator.runtimeAnimatorController != null)
        {
            _outfitAnimator.SetFloat("Horizontal", moveDirection.x);
            _outfitAnimator.SetFloat("Vertical", moveDirection.y);
            _outfitAnimator.SetFloat("Speed", moveDirection.sqrMagnitude);
        }
    }
}
