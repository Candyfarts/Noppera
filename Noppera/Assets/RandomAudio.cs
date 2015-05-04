using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using FMOD.Studio;

public class RandomAudio : MonoBehaviour {
	public FMODAsset asset;
	List<FMOD.Studio.EventInstance> events = new List<FMOD.Studio.EventInstance>();
	public int minTime, maxTime;
	[Range(0, 0.5f)]
	public float pitchRange;
	public int newTime;
	public bool overlapAllowed;
	public float pitch;


	public void Play(){
		FMOD.Studio.EventInstance evt = FMOD_StudioSystem.instance.GetEvent(asset);
		pitch = 1 - pitchRange + (UnityEngine.Random.value * pitchRange * 2);
		evt.setPitch(pitch);
		ERRCHECK(evt.start());
		events.Add (evt);
	}
	
	public void Stop(){
		foreach (FMOD.Studio.EventInstance e in events) {
			if (e != null)
			ERRCHECK(e.stop(STOP_MODE.IMMEDIATE));
		}		
	}	
	
	public FMOD.Studio.PLAYBACK_STATE getPlaybackState(FMOD.Studio.EventInstance evt){
		if (evt == null || !evt.isValid())
			return FMOD.Studio.PLAYBACK_STATE.STOPPED;
		
		FMOD.Studio.PLAYBACK_STATE state = PLAYBACK_STATE.STOPPED;
		
		if (ERRCHECK (evt.getPlaybackState(out state)) == FMOD.RESULT.OK)
			return state;
		
		return FMOD.Studio.PLAYBACK_STATE.STOPPED;
	}

	static bool isShuttingDown = false;
	
	void OnApplicationQuit() 
	{
		isShuttingDown = true;
	}
	
	void OnDestroy() 
	{
		if (isShuttingDown)
			return;
		
		FMOD.Studio.UnityUtil.Log("Destroy called");
		foreach (FMOD.Studio.EventInstance e in events) {
			if (e != null && e.isValid ()) {
				if (getPlaybackState (e) != FMOD.Studio.PLAYBACK_STATE.STOPPED) {
					ERRCHECK (e.stop (FMOD.Studio.STOP_MODE.IMMEDIATE));
				}
				ERRCHECK (e.release ());
			}
		}
	}
	
	void Update() {
		List<FMOD.Studio.EventInstance> remove = new List<FMOD.Studio.EventInstance>();
		foreach (FMOD.Studio.EventInstance e in events) {
			Debug.Log(e + " " + getPlaybackState (e));
			if (getPlaybackState (e) == FMOD.Studio.PLAYBACK_STATE.STOPPED){
				remove.Add(e);
				ERRCHECK (e.release ());
			}
		}
		foreach (FMOD.Studio.EventInstance e in remove) {
			events.Remove(e);
		}
		newTime -= (int) (Time.deltaTime * 1000);
		if (newTime <= 0) {
			newTime = minTime + (int)(UnityEngine.Random.value * (maxTime - minTime));
			if (overlapAllowed || events.Count == 0)
				Play();
		}
		Debug.Log (events.Count);
	}
	
	#if (UNITY_EDITOR)
	void OnDrawGizmosSelected() 
	{
		if (asset != null && enabled)
		{
			FMOD.Studio.EventDescription desc = null;
			desc = FMODEditorExtension.GetEventDescription(asset.id);
			
			if (desc != null)
			{
				float max, min;
				desc.getMaximumDistance(out max);
				desc.getMinimumDistance(out min);
				
				Gizmos.color = Color.blue;
				Gizmos.DrawWireSphere(transform.position, min);
				Gizmos.DrawWireSphere(transform.position, max);
			}
		}		
	}
	#endif
	
	FMOD.RESULT ERRCHECK(FMOD.RESULT result)
	{
		FMOD.Studio.UnityUtil.ERRCHECK(result);
		return result;
	}

}
