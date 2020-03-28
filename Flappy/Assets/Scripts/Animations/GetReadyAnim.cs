using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetReadyAnim : MonoBehaviour
{
    [SerializeField]
    private Bird bird;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGetReadyAnimEnds()
    {
        bird.OnGetReadyAnimFinished();
    }
}
