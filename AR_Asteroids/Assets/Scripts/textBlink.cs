using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class textBlink : MonoBehaviour
{
    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartBlinking();
        
    }
    IEnumerator Blink()
    {
        while (true)
        {
            if(text.text == "Play")
            {
               yield return new WaitForSeconds(.6f);
               text.text = "";
            }else {
                
                yield return new WaitForSeconds(.6f);
                text.text = "Play";

            }
           
            
            
        }
    
    }

    void StartBlinking(){
        StartCoroutine("Blink");
    }
    void StopBlinking()
    {
        StopCoroutine("Blink");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}