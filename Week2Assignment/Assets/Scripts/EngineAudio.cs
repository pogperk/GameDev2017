﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineAudio : MonoBehaviour {

	[Range(-1f, 1f)]
	public float offset;
    
	public float cutoffOn = 800;
	public float cutoffOff = 100;
    
	public bool engineOn = true;
    
    
	System.Random rand = new System.Random();
	AudioHighPassFilter _highPassFilter;
    
	void Awake() {
		_highPassFilter = GetComponent<AudioHighPassFilter>();
		Update();
	}
    
	void OnAudioFilterRead(float[] data, int channels) {
		for (int i = 0; i < data.Length; i++) {
			data[i] = (float)(rand.NextDouble() * 2.0 - 1.0 + offset);
		}
	}
    
	void Update() {
		_highPassFilter.cutoffFrequency = engineOn ? cutoffOn : cutoffOff;
	}
}
