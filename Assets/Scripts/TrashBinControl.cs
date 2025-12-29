using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TrashBinControl : MonoBehaviour
{

    private CollectableManager collectableManager;
    private ScoreManager scoreManager;
    private SfxManager sfxManager;
    void Start()
    {
        collectableManager = FindFirstObjectByType<CollectableManager>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
        sfxManager = FindFirstObjectByType<SfxManager>();
    }

    void Update()
    {
    }

    public void TrashClicked() {
        DiscardItemOn(gameObject.name);
    }

    public void DiscardItemOn(string ButtonName) {
        bool discardedCorrectly = false;
        switch (ButtonName) {
            case "TrashBinYellow":
                if (collectableManager.firstItem.sprite == collectableManager.metalSprite) {
                    discardedCorrectly = true;
                }
                break;
            case "TrashBinRed":
                if (collectableManager.firstItem.sprite == collectableManager.plasticSprite) {
                    discardedCorrectly = true;
                }
                break;
            case "TrashBinGreen":
                if (collectableManager.firstItem.sprite == collectableManager.glassSprite) {
                    discardedCorrectly = true;
                }
                break;
            case "TrashBinBlue":
                if (collectableManager.firstItem.sprite == collectableManager.paperSprite) {
                    discardedCorrectly = true;
                }
                break;
            case "TrashBinBrown":
                if (collectableManager.firstItem.sprite == collectableManager.organicSprite) {
                    discardedCorrectly = true;
                }
                break;
            default:
                Debug.Log("Nome da lixeira não identificado");
                break;
        }
        if (discardedCorrectly) {
            Debug.Log("Descartou corretamente");
            scoreManager.IncreaseScoreDiscard();
            scoreManager.IncreaseStreak();
            collectableManager.RemoveItem();
        }
        else {
            Debug.Log("Lixeira errada");
            scoreManager.DecreaseScore();
            scoreManager.StreakEnded();
        }
        collectableManager.ShowIcon(discardedCorrectly); //Mostra icone correto se player descartou corretamente, ou errado se descartou na lixeira errada
        sfxManager.PlayDiscardSfx(discardedCorrectly); //Tocar SFX correto com base na situação
    }
}
