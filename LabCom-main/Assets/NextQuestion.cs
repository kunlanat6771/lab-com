using UnityEngine;

public class NextQuestion : MonoBehaviour
{
    public GameObject question1;
    public GameObject question2;

    public void Next()
    {
        question1.SetActive(false);
        question2.SetActive(true);
    }
}