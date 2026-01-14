using UnityEngine;
using UnityEngine.SceneManagement;

public class menuBack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openMenu()
    {
        SceneManager.LoadScene(0);
    }

}
