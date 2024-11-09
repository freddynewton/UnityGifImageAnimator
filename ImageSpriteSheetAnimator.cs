using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ImageSpriteSheetAnimator : MonoBehaviour
{
    [Header("Sprite Animation Settings")]
    [Tooltip("The UI Image component where the sprite sheet animation will play.")]
    [SerializeField] private Image targetImage;

    [Tooltip("Time in seconds between frames.")]
    [SerializeField] private float frameRate = 0.1f;

    private bool loop = true;
    private int currentFrame;
    private Coroutine animationCoroutine;
    private Sprite[] animationFrames;

    /// <summary>
    /// Starts the sprite sheet animation with looping behavior.
    /// </summary>
    /// <param name="animationFrames">Array of sprites to animate through.</param>
    /// <param name="loop">Set to true for infinite looping, false for a one-time animation.</param>
    public void StartAnimation(Sprite[] animationFrames, bool loop)
    {
        if (animationFrames.Length > 0)
        {
            this.animationFrames = animationFrames;

            // Stop any ongoing animation before starting a new one
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }

            animationCoroutine = StartCoroutine(PlayAnimation(animationFrames, loop));
        }
    }

    /// <summary>
    /// Stops the currently playing sprite sheet animation.
    /// </summary>
    public void StopAnimation()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
            animationCoroutine = null;
        }
    }

    /// <summary>
    /// Sets the first frame of the animation (without playing it).
    /// </summary>
    public void SetFirstFrame(Sprite[] animationFrames)
    {
        if (animationFrames == null || animationFrames.Length == 0)
        {
            targetImage.sprite = null;
            return;
        }

        targetImage.sprite = animationFrames.First();
    }

    /// <summary>
    /// Plays the sprite sheet animation once without looping.
    /// </summary>
    public void PlayOneShotAnimation(Sprite[] animationFrames)
    {
        if (animationFrames.Length > 0)
        {
            StopAnimation(); // Stop any ongoing animation
            animationCoroutine = StartCoroutine(PlayOneShot(animationFrames));
        }
    }

    /// <summary>
    /// Plays the sprite sheet animation once without looping.
    /// </summary>
    private IEnumerator PlayOneShot(Sprite[] animationFrames)
    {
        foreach (var frame in animationFrames)
        {
            targetImage.sprite = frame;
            yield return new WaitForSeconds(frameRate);
        }
    }

    /// <summary>
    /// Sets a new frame rate for the animation.
    /// </summary>
    /// <param name="newFrameRate">New frame rate in seconds between frames.</param>
    public void SetFrameRate(float newFrameRate)
    {
        frameRate = newFrameRate;
    }

    /// <summary>
    /// Resets the animation to the first frame.
    /// </summary>
    public void ResetAnimation()
    {
        currentFrame = 0;
        targetImage.sprite = targetImage.sprite;
    }

    /// <summary>
    /// Toggles whether the animation loops.
    /// </summary>
    /// <param name="shouldLoop">Set to true to enable looping, false to disable.</param>
    public void SetLoop(bool shouldLoop)
    {
        loop = shouldLoop;
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine); // Stop the current animation
            animationCoroutine = StartCoroutine(PlayOneShot(animationFrames)); // Play the first frame
        }
    }

    /// <summary>
    /// Plays the sprite sheet animation, looping if 'loop' is true.
    /// </summary>
    private IEnumerator PlayAnimation(Sprite[] animationFrames, bool loop)
    {
        this.loop = loop;

        while (this.loop)
        {
            // Cycle through the frames
            foreach (var frame in animationFrames)
            {
                targetImage.sprite = frame;
                yield return new WaitForSeconds(frameRate); // Wait for the next frame
            }
        }
    }

    private void Start()
    {
        // Ensure the targetImage is assigned, or try to get the Image component if not set
        targetImage ??= GetComponent<Image>();
    }
}
