using UnityEngine;
using UnityEngine.SceneManagement;

public class HudControl : MonoBehaviour
{
    private float cont = 0;

    private void Update()    {
        
        if (PlayerHealth.loadNextScene == true)
        {
            cont += 1 * Time.deltaTime;
            if (cont >= 6f)
            {
                LoadScenes("Menus");
                PlayerHealth.loadNextScene = false;                
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }
    }   
    
    public void LoadScenes(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {     
        Application.Quit();                 
    }
}
