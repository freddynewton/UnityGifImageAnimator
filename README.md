### ImageSpriteSheetAnimator - README

#### Overview

`ImageSpriteSheetAnimator` is a Unity script that lets you play sprite sheet animations, which can be useful for creating GIF-like or frame-based animations. The script provides control over speed, looping, and animation playback, offering more flexibility than directly using GIF files in Unity.

---

### Features

- **Frame Control**: Play animations frame by frame from a sprite sheet.
- **Looping**: Optionally loop the animation.
- **One-shot Animation**: Play the animation once and stop.
- **Frame Rate Control**: Adjust the frame rate to control the speed of the animation.
- **Stop and Reset**: Stop the animation and reset it to the first frame.

---

### Setup

1. **Create a UI Image**: This will display the sprite sheet animation.
   - Right-click in the **Hierarchy** > **UI** > **Image**.

2. **Import Sprite Sheet**: Export your GIF as a sprite sheet.
   - Use a tool like **[ezgif.com](https://ezgif.com/sprite-sheet)** to export the GIF as a sprite sheet.
   - Import the sprite sheet into Unity.
   - Set the **Texture Type** to **Sprite (2D and UI)** and **Sprite Mode** to **Multiple** in the **Inspector**.

3. **Slice the Sprite Sheet**: Use the **Sprite Editor** to slice the sprite sheet into individual frames.
   - Open the **Sprite Editor** and slice the sprite sheet into individual sprites.

4. **Add the Script**: Attach the `ImageSpriteSheetAnimator` script to the GameObject with the `Image` component.
   - In the **Inspector**, assign the `Image` component to the `targetImage` field.
   - Assign the array of sprites (sliced frames from your sprite sheet) to the `animationFrames` field.

---

### Code Usage

#### Start Animation

Start the animation by calling the `StartAnimation` method, which will loop the animation:

```csharp
public class GIFPlayer : MonoBehaviour
{
    [SerializeField] private Sprite[] gifSprites; // Array of sprites for the sprite sheet
    [SerializeField] private ImageSpriteSheetAnimator spriteSheetAnimator;

    void Start()
    {
        // Start the animation with looping
        spriteSheetAnimator.StartAnimation(gifSprites, true);
    }
}
```

#### Play One-shot Animation

If you want the animation to play once without looping, use the `PlayOneShotAnimation` method:

```csharp
public class GIFPlayer : MonoBehaviour
{
    [SerializeField] private Sprite[] gifSprites; // Array of sprites for the sprite sheet
    [SerializeField] private ImageSpriteSheetAnimator spriteSheetAnimator;

    void Start()
    {
        // Play the animation once without looping
        spriteSheetAnimator.PlayOneShotAnimation(gifSprites);
    }
}
```

#### Stop the Animation

You can stop the animation at any time with:

```csharp
spriteSheetAnimator.StopAnimation();
```

#### Set Frame Rate

You can change the frame rate (time between frames) with the `SetFrameRate` method:

```csharp
spriteSheetAnimator.SetFrameRate(0.05f); // Adjust frame rate to 0.05 seconds per frame
```

---

### Methods

- **StartAnimation(Sprite[] animationFrames, bool loop)**: Starts the animation with the provided sprite frames. Loops if `loop` is true.
- **PlayOneShotAnimation(Sprite[] animationFrames)**: Plays the animation once through the frames.
- **StopAnimation()**: Stops the current animation.
- **SetFrameRate(float newFrameRate)**: Sets the new frame rate in seconds between frames.
- **SetLoop(bool shouldLoop)**: Sets whether the animation should loop.

---

### Notes

- **Sprite Sheet Layout**: Ensure your sprite sheet is laid out in a grid, with each frame placed side by side or in a grid format.
- **Performance**: This method is ideal for simple animations, UI effects, or games that don’t need the complexity of video files or animated textures.
- **Unity Version**: This script is designed for Unity's UI system and works well with **Unity 2020.x** and above.

---

### License

This script is provided free of charge and can be used in personal and commercial projects. Feel free to modify and adapt it to fit your needs.
