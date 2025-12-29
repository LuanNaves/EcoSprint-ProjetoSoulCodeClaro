using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource collectSfx;
    public AudioSource discardRightSfx;
    public AudioSource discardWrongSfx;
    public AudioSource bgMusic;
    void Start()
    {
        bgMusic.Play();
    }

    public void PlayDiscardSfx(bool discardedCorrectly) {
        if (discardedCorrectly) {
            discardRightSfx.Play();
        } else {
            discardWrongSfx.Play();
        }
    }

    public void PlayCollectSfx() {
        collectSfx.Play();
    }
}
