using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using FMOD.Studio;

public class BackgroundAudio : MonoBehaviour {
	public FMODAsset asset;
	public GameObject target;
	public FMOD.Studio.EventInstance evt;
	public float delay;

	public void Play(){
		if (evt == null || !evt.isValid())
			evt = FMOD_StudioSystem.instance.GetEvent(asset);

		if (evt != null){
			ERRCHECK(evt.start());
		}
	}
	
	public void Stop(){
		if (evt != null){
			ERRCHECK(evt.stop(STOP_MODE.IMMEDIATE));
		}		
	}	
	
	public FMOD.Studio.PLAYBACK_STATE getPlaybackState()
	{
		if (evt == null || !evt.isValid())
			return FMOD.Studio.PLAYBACK_STATE.STOPPED;
		
		FMOD.Studio.PLAYBACK_STATE state = PLAYBACK_STATE.STOPPED;
		
		if (ERRCHECK (evt.getPlaybackState(out state)) == FMOD.RESULT.OK)
			return state;
		
		return FMOD.Studio.PLAYBACK_STATE.STOPPED;
	}
	
	void Start(){
		if (delay <= 0)
			Play();
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
		if (evt != null && evt.isValid()) 
		{
			if (getPlaybackState () != FMOD.Studio.PLAYBACK_STATE.STOPPED)
			{
				ERRCHECK (evt.stop(FMOD.Studio.STOP_MODE.IMMEDIATE));
			}
			
			ERRCHECK(evt.release ());
			evt = null;
		}
	}

	void Update() {
		if (evt != null && target != null)
			evt.set3DAttributes (UnityUtil.to3DAttributes(target.transform.position));
		if (delay > 0)
			delay -= (int)(Time.deltaTime * 1000);
		else if (getPlaybackState () == FMOD.Studio.PLAYBACK_STATE.STOPPED)
			Play();
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
