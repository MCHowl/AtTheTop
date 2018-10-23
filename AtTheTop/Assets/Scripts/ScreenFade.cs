using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour {

    public delegate void DayEnd();
    public static event DayEnd DayEndEvent;

    [SerializeField]
    bool isFadeToBlack;

    [SerializeField]
    float fadeTime;

    SpriteRenderer sprite;

	void Start () {
        sprite = GetComponent<SpriteRenderer>();

        if (isFadeToBlack) {
            setAlpha(0);
        } else {
            setAlpha(1);
        }

        if (!isFadeToBlack) {
            StartCoroutine(FadeToWhite());
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (isFadeToBlack) {
            StartCoroutine(FadeToBlack());
        }
    }

    void setAlpha(float newAlpha) {
        Color spriteColor = sprite.color;
        spriteColor.a = newAlpha;
        sprite.color = spriteColor;
    }

    IEnumerator FadeToWhite() {
        while (sprite.color.a > 0) {
            setAlpha(sprite.color.a - Time.deltaTime / fadeTime);
            yield return null;
        }

        isFadeToBlack = true;
        GameController.Paused = false;
        yield return null;
    }

    IEnumerator FadeToBlack() {
        GameController.Paused = true;

        while (sprite.color.a < 1)
        {
            setAlpha(sprite.color.a + Time.deltaTime / fadeTime);
            yield return null;
        }

        isFadeToBlack = false;
        DayEndEvent();
        yield return null;
    }
}
