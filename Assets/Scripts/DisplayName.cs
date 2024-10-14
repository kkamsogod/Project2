using TMPro;
using UnityEngine;

public class DisplayName : MonoBehaviour
{
    public TMP_Text playerNameText;
    private Transform player;

    private void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");

        playerNameText.text = playerName;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            playerNameText.transform.position = player.position + new Vector3(0, 1, 0);
        }
    }

    public void SetPlayer(Transform newPlayer)
    {
        player = newPlayer;
    }
}
