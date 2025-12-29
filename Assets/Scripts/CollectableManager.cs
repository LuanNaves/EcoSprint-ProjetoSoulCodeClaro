using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CollectableManager : MonoBehaviour {
    private ScoreManager scoreManager;

    public Image firstItem;
    public Image secondItem;
    public Image firstSlot;

    public RectTransform correctIcon;
    public RectTransform wrongIcon;

    [HideInInspector] public Sprite metalSprite;
    [HideInInspector] public Sprite plasticSprite;
    [HideInInspector] public Sprite glassSprite;
    [HideInInspector] public Sprite paperSprite;
    [HideInInspector] public Sprite organicSprite;


    Color slotImageColor = Color.white;

    public static List<string> collectableTypeList = new List<string>();

    void Awake() {
        collectableTypeList.Clear();
    }
    void Start() {
        scoreManager = FindFirstObjectByType<ScoreManager>();

        metalSprite = Resources.Load<Sprite>("Images/MetalHudImage");
        plasticSprite = Resources.Load<Sprite>("Images/PlasticHudImage");
        glassSprite = Resources.Load<Sprite>("Images/GlassHudImage");
        paperSprite = Resources.Load<Sprite>("Images/PaperHudImage");
        organicSprite = Resources.Load<Sprite>("Images/OrganicHudImage");
    }

    public void AddItem(int imageIndex) {
        switch (imageIndex) {
            case 7:
                collectableTypeList.Add("Metal");
                Debug.Log("Metal recolhido");
                break;
            case 8:
                collectableTypeList.Add("Plastic");
                Debug.Log("Plastico recolhido");
                break;
            case 9:
                collectableTypeList.Add("Glass");
                Debug.Log("Vidro recolhido");
                break;
            case 10:
                collectableTypeList.Add("Paper");
                Debug.Log("Papel recolhido");
                break;
            case 11:
                collectableTypeList.Add("Organic");
                Debug.Log("Organico recolhido");
                break;
            default:
                Debug.Log("Objeto sem Layer correta");
                break;
        }
        scoreManager.IncreaseStreak();
        scoreManager.IncreaseScoreWhenCollected();
        UpdateHud();
    }

    public void RemoveItem() {
        if (collectableTypeList.Count > 0) {
            collectableTypeList.RemoveAt(0);
            UpdateHud();
        }
    }

    public void UpdateHud() {
        //Atualizando primeiro Slot
        if (collectableTypeList.Count > 0) {
            slotImageColor.a = 1f; //Aumenta opacidade do sprite
            firstItem.color = slotImageColor;
            switch (collectableTypeList.ElementAt(0)) {
                case "Metal":
                    firstItem.sprite = metalSprite;
                    firstSlot.color = Color.yellow;
                    break;
                case "Plastic":
                    firstItem.sprite = plasticSprite;
                    firstSlot.color = Color.red;
                    break;
                case "Glass":
                    firstItem.sprite = glassSprite;
                    firstSlot.color = Color.green;
                    break;
                case "Paper":
                    firstItem.sprite = paperSprite;
                    firstSlot.color = Color.blue;
                    break;
                case "Organic":
                    firstItem.sprite = organicSprite;
                    firstSlot.color = Color.saddleBrown;
                    break;
                default:
                    Debug.Log("Não reconheceu na lista");
                    break;
            }
        }
        else {
            //Limpa primeiro Slot quando não tem mais items
            firstItem.sprite = null;
            slotImageColor.a = 0f; //Deixa imagem transparente
            firstItem.color = slotImageColor;
            firstSlot.color = Color.white;
        }

        //Atualizando segundo Slot
        if (collectableTypeList.Count > 1) {
            slotImageColor.a = 1f;
            secondItem.color = slotImageColor;
            switch (collectableTypeList.ElementAt(1)) {
                case "Metal":
                    secondItem.sprite = metalSprite;
                    break;
                case "Plastic":
                    secondItem.sprite = plasticSprite;
                    break;
                case "Glass":
                    secondItem.sprite = glassSprite;
                    break;
                case "Paper":
                    secondItem.sprite = paperSprite;
                    break;
                case "Organic":
                    secondItem.sprite = organicSprite;
                    break;
                default:
                    Debug.Log("Não reconheceu na lista");
                    break;
            }
        }
        else {
            //Limpa segundo Slot quando não tem mais items
            secondItem.sprite = null;
            slotImageColor.a = 0f;
            secondItem.color = slotImageColor;
        }
    }

    // Mostra Icone de certo ou errado se descartou corretamente ou erroneamente
    public void ShowIcon(bool discardedCorrectly) {
        if (discardedCorrectly) {
            correctIcon.gameObject.GetComponent<Animator>().SetTrigger("Play");
        }
        else {
            wrongIcon.gameObject.GetComponent<Animator>().SetTrigger("Play");
        }
    }
}

