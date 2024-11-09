using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Animator for images to show gifs.
/// </summary>
public class ImageSpriteSheetAnimator : MonoBehaviour
{
    [Header("Sprite Animation Settings")]
    [Tooltip("The UI Image component where the sprite sheet animation will play.")]
    [SerializeField] private Image targetImage;

    [Tooltip("Time in seconds between frames.")]
    [SerializeField] private float frameRate = 0.1f;

    private bool loop = true;
    private int currentFrame;
    private Task animationTask;

    /// <summary>
    /// Starts the sprite sheet animation with looping behavior.
    /// </summary>
    /// <param name="animationFrames">Array of sprites to animate through.</param>
    /// <param name="loop">Set to true for infinite looping, false for a one-time animation.</param>
    public async void StartAnimation(Sprite[] animationFrames, bool loop)
    {
        if (animationFrames.Length > 0)
        {
            // Stop any ongoing animation before starting a new one
            if (animationTask != null)
            {
                await animationTask; // Wait for the current task to complete
            }

            animationTask = PlayAnimation(animationFrames, loop);
            await animationTask; // Run the animation task asynchronously
        }
    }

    /// <summary>
    /// Stops the currently playing sprite sheet animation.
    /// </summary>
    public void StopAnimation()
    {
        animationTask = null;
    }

    /// <summary>
    /// Stops the looped animation and prevents further looping.
    /// </summary>
    public void StopLoop()
    {
        loop = false;
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
            animationTask = PlayOneShot(animationFrames);
        }
    }

    /// <summary>
    /// Plays the sprite sheet animation once without looping.
    /// </summary>
    private async Task PlayOneShot(Sprite[] animationFrames)
    {
        foreach (var frame in animationFrames)
        {
            targetImage.sprite = frame;
            await Task.Delay((int)(frameRate * 1000)); // Convert to milliseconds
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
        if (animationTask != null)
        {
            StopAnimation(); // Stop the current animation
            StartAnimation(targetImage.sprite != null ? new Sprite[1] : new Sprite[0], loop); // Restart with the new loop setting
        }
    }

    /// <summary>
    /// Plays the sprite sheet animation, looping if 'loop' is true.
    /// </summary>
    private async Task PlayAnimation(Sprite[] animationFrames, bool loop)
    {
        this.loop = loop;

        while (this.loop)
        {
            // Cycle through the frames
            foreach (var frame in animationFrames)
            {
                targetImage.sprite = frame;
                await Task.Delay((int)(frameRate * 1000)); // Wait for the next frame
            }
        }
    }

    private void Start()
    {
        // Ensure the targetImage is assigned, or try to get the Image component if not set
        targetImage ??= GetComponent<Image>();
    }
}
