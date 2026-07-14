using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void ReloadLevel()
    {
        StartCoroutine(ReloadLevelRoutine()); //to start the coroutine we have to write the name inside StartCoroutine();
    }

    IEnumerator ReloadLevelRoutine()
    {
        yield return new WaitForSeconds(1f);  //it will wait for 1 second before changing the frame(here : Wait for 1 second before restarting the lvl);
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currenSceneIndex);
    }
}
