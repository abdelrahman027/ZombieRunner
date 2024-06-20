using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas GameOverCanvas;
    PlayerHealth playerHealth;
    void Start()
    {
        GameOverCanvas.enabled = false;
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    public void HandleDeath()
    {
        Cursor.lockState =CursorLockMode.None;
        Cursor.visible =true;
        Time.timeScale = 0;
        GameOverCanvas.enabled = true;
    }
}
