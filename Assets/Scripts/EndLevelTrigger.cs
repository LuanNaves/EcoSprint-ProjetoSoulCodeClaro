using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    private GameManager gameManager;

    private void Start() {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            gameManager.LevelFinished();
        }
    }
}
