using UnityEngine;

public class CharacterSelectScene : MonoBehaviour
{
    private int selectedCharacterIndex = -1;

    public void SelectCharacter(int characterIndex)
    {
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        selectedCharacterIndex = characterIndex;
    }

    public void CloseCharacterSelection()
    {
        gameObject.SetActive(false);
    }
}