using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public GameObject penguin;
    public GameObject dragon;
    public CameraFollow cameraFollow;

    private void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);

        penguin.SetActive(false);
        dragon.SetActive(false);

        if (selectedCharacter == 0)
        {
            penguin.SetActive(true);
            cameraFollow.SwitchCharacter(penguin.transform);
        }
        else if (selectedCharacter == 1)
        {
            dragon.SetActive(true);
            cameraFollow.SwitchCharacter(dragon.transform);
        }
    }
}