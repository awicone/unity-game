using UnityEngine;

public class CubeTrigger : MonoBehaviour
{
    bool showHint = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            showHint = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            showHint = false;
        }
    }

    void OnGUI()
    {
        if (showHint)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Press F to jump on the cube");
        }
    }
}
