using UnityEngine;
using System.Collections;

public class LightningPlayer : MonoBehaviour {

    private int timer;
    private Light light;

    void Start()
    {
        light = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        timer++;
        if (timer == 600)
        {
            light.enabled = true;
        }else if(timer == 604){
            light.enabled = false;
        }else if(timer == 610)
        {
            light.intensity = 5;
            light.enabled = true;
        }else if(timer == 614)
        {
            light.enabled = false;
        }
        else if(timer == 618)
        {
            light.intensity = 2;
            light.enabled = true;
        }
        else if (timer == 622)
        {
            light.enabled = false;
            light.intensity = 8;
            timer = 0;
        }
	}
}
