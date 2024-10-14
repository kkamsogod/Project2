using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform activePlayer;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10f);

    private void LateUpdate()
    {
        if (activePlayer != null)
        {
            transform.position = activePlayer.position + offset;
        }
    }

    public void SwitchCharacter(Transform newPlayer)
    {
        activePlayer = newPlayer;
    }
}