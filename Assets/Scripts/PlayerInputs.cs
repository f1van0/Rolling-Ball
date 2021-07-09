using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public static PlayerInputs instance;
    public BallController ballController;

    void Awake()
    {
        if (instance == null)
        {
            instance = this.GetComponent<PlayerInputs>();
        }
        else
        {
            Debug.Log("PlayerInputs object already exists!");
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
