using UnityEngine;

public class MusicPlayer : MonoBehaviour   //this script makes sure that when we die and respawn, the music doesn't restart but keeps playing;
{
    void Start()
    {
        int numOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length; //Remember the syntax because this is from old unity version - shi stephen hubbard said.

        if(numOfMusicPlayers > 1)  //we know that there will be only 1 musicplayer in our scene(main bg music) and if it increases then destroy it else don't
        {                          //like when we click play, else part is executed and each time we crashes, if part executes and destroys every other instances of this musicplayer gameobject.
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}



