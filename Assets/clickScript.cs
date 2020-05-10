using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void ClickA()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
