using UnityEngine;

public class PlatformCheck : MonoBehaviour
{
    public GameObject mobileControls;
    void Awake() {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.LinuxPlayer) {
            Debug.Log("O jogador está no PC!");
            mobileControls.gameObject.SetActive(false);
        }
        else if (Application.platform == RuntimePlatform.Android) {
            Debug.Log("O jogador está no Android!");
            mobileControls.gameObject.SetActive(true);
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer) {
            Debug.Log("O jogador está no iOS!");
            mobileControls.gameObject.SetActive(true);
        } 
    }

    void Update()
    {
        
    }
}
