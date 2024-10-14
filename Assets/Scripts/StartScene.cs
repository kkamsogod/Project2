using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public string mainSceneName = "MainScene";
    private int selectedCharacterIndex;

    private void Start()
    {
        selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", -1);
    }

    public void OnStartButtonClicked()
    {
        if (selectedCharacterIndex == -1)
        {
            return;
        }

        string playerName = playerNameInput.text.Trim();
        if (playerName.Length < 2 || playerName.Length > 10)
        {
            return;
        }

        PlayerPrefs.SetString("PlayerName", playerName);
        SceneManager.LoadScene(mainSceneName);
    }
}
