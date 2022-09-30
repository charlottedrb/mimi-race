using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Change the value of the animation.
    public void ToggleAnimation(string animationName)
    {
        froggyAnimator.SetBool(animationName, !froggyAnimator.GetBool(animationName));
    }
}
