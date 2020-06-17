using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject DeathFX;
    [SerializeField] Transform parent;

    [SerializeField] int scorePerHit = 12;

    ScoreBoard scoreBoard;
    void Start()
    {
        Collider addBoxCollider = gameObject.AddComponent<BoxCollider>();
        addBoxCollider.isTrigger = false;
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.scoreHit(scorePerHit);
        GameObject fx = Instantiate(DeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

    
}
