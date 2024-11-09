### ImageSpriteSheetAnimator - README

#### Overview

`ImageSpriteSheetAnimator` is a Unity script that allows you to play sprite sheet animations, which can be useful for playing GIFs or frame-based animations in your Unity projects. This script lets you control the speed, looping, and display of animations using sprite sheets, giving you more flexibility than directly using GIF files in Unity.

---

### Features

- **Frame Control**: Play animations frame by frame from a sprite sheet.
- **Looping**: Optionally loop the animation.
- **One-shot Animation**: Play the animation once and stop.
- **Frame Rate Control**: Easily adjust the frame rate to control the speed of the animation.
- **Stop and Reset**: Stop the animation and reset it to the first frame.

---

### Setup

1. **Create a UI Image**: This will be used to display the sprite sheet animation.
   - Right-click in the **Hierarchy** > **UI** > **Image**.

2. **Import Sprite Sheet**: You need to export your GIF as a sprite sheet.
   - Export the GIF as a sprite sheet using tools like **[ezgif.com](https://ezgif.com/sprite-sheet)**.
   - Import the sprite sheet into Unity.
   - Set the **Texture Type** to **Sprite (2D and UI)** and **Sprite Mode** to **Multiple** in the **Inspector**.

3. **Slice the Sprite Sheet**: Use the **Sprite Editor** to slice the sprite sheet into individual frames.
   - Open the **Sprite Editor** and slice the sprite sheet into individual sprites.

4. **Add the Script**: Attach the `ImageSpriteSheetAnimator` script to the GameObject with the `Image` component.
   - In the **Inspector**, assign the `Image` component to the `targetImage` field in the script.
   - Assign the array of sprites to the `animationFrames` field (the sliced sprites from your sprite sheet).

---

### Code Usage

#### Start Animation

You can start the animation by calling the `StartAnimation` method, which will loop the animation:

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

If you only want the animation to play once, use the `PlayOneShotAnimation` method:

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

You can stop the animation at any time by calling:

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

- **Sprite Sheet Layout**: Make sure your sprite sheet is laid out in a grid, with each frame placed side by side or in a grid format.
- **Performance**: This method is ideal for simple animations, UI effects, or games that don’t need the complexity of video files or animated textures.
- **Unity Version**: This script is designed for Unity's UI system and works well with **Unity 2020.x** and above.

---

### License

This script is provided free of charge and can be used in personal and commercial projects. Feel free to modify and adapt it to fit your needs.
