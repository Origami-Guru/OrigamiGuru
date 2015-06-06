using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Soomla;
using Soomla.Profile;


public class SoomlaInitialize : MonoBehaviour {
	// Use this for initialization
	void Start () {
		SoomlaProfile.Initialize();
	}
	
	public void shareStory(string currentModelSceneName){
		// When a user updates this story, they'll receive a soombotReward (free "Soombot").

		Debug.Log("try to sharing a story in facebook");
		SoomlaProfile.UpdateStory(
		    Provider.FACEBOOK,                          // Provider
		    "Check out this great origami experience by Origami Guru! #OrigamiGuru #SWU",                       // Text of the story to post
		    "Origami Guru is so lovely app :P",  // Name
		    "Origami Guru is growing!!",                            // Caption
		    "Origami Guru",                     // Description
		    "https://www.facebook.com/origamiguruswu",            // Link to post
		    "http://gatukgl.ascii-coma.com/images/" + currentModelSceneName + ".png",    // Image URL
		    "",                                         // Payload
		    new BadgeReward(currentModelSceneName + "Reward", currentModelSceneName + "Reward")     // Reward for posting a story
		);
	}
}
