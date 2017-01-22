using UnityEngine;
using System.Collections;

public class Voice : MonoBehaviour {


    public AudioSource _audioSource;
    private AudioClip[] _audioDeath;
    private AudioClip[] _audioEnemy;
    private AudioClip[] _audioHurt;
    private AudioClip _sam;

    // Use this for initialization
    void Start () {
        _audioSource = gameObject.GetComponentInChildren<AudioSource>();
        _audioDeath = Resources.LoadAll<AudioClip>("Audio/Voices/Death");
        _audioEnemy = Resources.LoadAll<AudioClip>("Audio/Voices/Enemy");
        _audioHurt = Resources.LoadAll<AudioClip>("Audio/Voices/Hurt");
        _sam = Resources.Load<AudioClip>("Audio/Voices/Sam/Hey");
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public AudioSource getRandomDeath()
    {
        int rng = Random.Range(0, _audioDeath.Length);
        _audioSource.clip = _audioDeath[rng];
        return _audioSource;
    }

    public AudioSource getRandomEnemy()
    {
        int rng = Random.Range(0, _audioEnemy.Length);
        _audioSource.clip = _audioEnemy[rng];
        return _audioSource;
    }

    public AudioSource getRandomHurt()
    {
        int rng = Random.Range(0, _audioHurt.Length);
        _audioSource.clip = _audioHurt[rng];
        return _audioSource;
    }

    public AudioSource getSamSurprice()
    {
        _audioSource.clip = _sam;
        return _audioSource;
    }
}
