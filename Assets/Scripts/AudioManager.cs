using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;


	// Use this for initialization
	void Awake () {

        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);
		foreach(Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    private void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 30), "Current music is: " + sounds);

    }

    private void Start() {
        Play("MenuMusic");
        Debug.Log("Start theme music");
    }

    public void LevelStart() {
        Stop("MenuMusic");
        Play("StageMusic");
    }

    public void StartStage() {
        Stop("MenuMusic");
        Play("StageMusic");
    }

    public void Play (string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null) {
            Debug.LogWarning("Play " + name + " was not found");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Stop " + name + " was not found");
            return;
        }

        s.source.Stop();
    }

}
