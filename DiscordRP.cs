using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiscordPresence;

public class DiscordRP : MonoBehaviour

{
	public string detail;
    public string state;
	
    // Start is called before the first frame update
    public void Button()
    {
       PresenceManager.UpdatePresence(detail: detail, state:state);
    }

}
