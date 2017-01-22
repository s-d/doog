using UnityEngine;
using System.Collections;

public class PlayList : MonoBehaviour {

    private int _currentTrack = 0;
    private AudioSource _audioSource;
    private AudioClip[] _audioClips;
    private bool _changing = false;

	// Use this for initialization
	void Awake () {
        _audioSource = gameObject.GetComponentInChildren<AudioSource>();
        _audioClips = Resources.LoadAll<AudioClip>("Audio/Drum_Loops");
        _audioSource.loop = true;
        _audioSource.clip = _audioClips[_currentTrack];
        _audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (!_changing)
        {
            Debug.Log("Changing");
            StartCoroutine(beatChange());
        }

        if (Spawner.dead)
        {
            _changing = true;
            _audioSource.Stop();
        }
	}

    

    IEnumerator beatChange()
    {
        _changing = true;
        _currentTrack = Random.Range(0, _audioClips.Length);
        _audioSource.clip = _audioClips[_currentTrack];
        _audioSource.Play();
        yield return new WaitForSeconds(15);
        _changing = false;
    }
}
