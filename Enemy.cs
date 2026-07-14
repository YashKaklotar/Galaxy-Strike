using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 10;
    ScoreBoard scoreBoard;  //reference of the scoreboard class.
    private void Start()
    {
        scoreBoard = FindFirstObjectByType<ScoreBoard>();  //this will go through our entire project and find the first object of type ScoreBoard and send our reference scoreBoard to that.
    }
    void OnParticleCollision(GameObject other)
    {
        processHit();
    }

    public void processHit()
    {
        hitPoints--;
        
        if (hitPoints <= 0)
        {
            scoreBoard.IncreaseScore(scoreValue);
            Instantiate(destroyedVFX, transform.position, destroyedVFX.transform.rotation); //this line manages to instantiate and apply particles when an enemy is destryed. for that we have given the vfx, position of that particle and rotation which will be 0,0,0 most of the time. Instead of writing destroyVFX.transform.rotation we can just write Quaternion.identity which will by default return the rotation as 0,0,0.
            Destroy(this.gameObject); //this is completely optional    
        }
    }
}


