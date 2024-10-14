using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
    public GameObject targetObject1;
    public GameObject targetObject2;
    public GameObject targetObject3;
    public GameObject targetObject4;

    private void Start()
    {        
        targetObject1.SetActive(true);
        targetObject2.SetActive(true);
        targetObject3.SetActive(true);
        targetObject4.SetActive(true);
    }
}