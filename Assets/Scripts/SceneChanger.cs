using UnityEngine;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public GameObject characterSelectionPanel;
    public Image imageToDisable;

    public void OnImageClicked()
    {
        characterSelectionPanel.SetActive(true);

        Color tempColor = imageToDisable.color;
        tempColor.a = 0f;
        imageToDisable.color = tempColor;
    }
}
