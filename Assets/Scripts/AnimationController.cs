using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Tooltip("Animator which concern Froggy.")]
    public Animator froggyAnimator;
    private static AnimationController _instance;
    public static AnimationController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<AnimationController>();
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }
    
    // Change the value of the animation.
    public void ToggleAnimation(string animationName)
    {
        // Change bool value of the concerned animation.
        froggyAnimator.SetBool(animationName, !froggyAnimator.GetBool(animationName));
    }
}
