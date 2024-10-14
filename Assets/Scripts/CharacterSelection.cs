using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject characterSelectionPanel;
    public GameObject selectedCharacterParent;
    public GameObject[] characterPrefabs;

    private GameObject currentCharacter;

    private void Awake()
    {
        characterSelectionPanel.SetActive(false);
    }

    public void SelectCharacter(int characterIndex)
    {
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }

        GameObject newCharacter = Instantiate(characterPrefabs[characterIndex], selectedCharacterParent.transform);
        currentCharacter = newCharacter;

        newCharacter.transform.localPosition = Vector3.zero;
        newCharacter.transform.localScale = Vector3.one;

        characterSelectionPanel.SetActive(false);
    }

    public void OpenCharacterSelection()
    {
        characterSelectionPanel.SetActive(true);
    }
}
