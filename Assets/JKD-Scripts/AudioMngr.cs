using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioMngr : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource; 
    public AudioSource subtitleSource; 
    public AudioSource deductionSource; 
    public AudioSource gameOverSource; 
    public AudioSource timerSource; 

    [Header("BG Music")]
    public AudioClip[] bgMusic;

    [Header("SFX")]
    public AudioClip whooseFire;
    public AudioClip lighterFX;
    public AudioClip lighter2ONFX;
    public AudioClip lighter2OFFFX;
    public AudioClip openDoorFX;
    public AudioClip closeDoorFX;
    public AudioClip checkpointFX;
    public AudioClip collectedPointsFX;
    public AudioClip gameoverNegativeSound;
    public AudioClip timerfx;
    public AudioClip wearCoatfx;
    public AudioClip wearGogglesfx;
    public AudioClip wearGlovesfx;


    [Header("VRBot Voice Over")]
    public AudioClip[] vrBotVoice;
    public AudioClip[] vrBotVoice2;
    public AudioClip[] vrBotVoice3;
    public AudioClip[] vrBotVoice4;
    public AudioClip[] vrBotVoice5;
    public AudioClip[] verdict;
    public AudioClip vrBotNice;
    public AudioClip forgetToCloseValve;
    public AudioClip GameOverClip;

    // Chem reactions
    public AudioClip[] vrBotReactions; //S2
    public AudioClip[] vrBotReactions3; //S3
    public AudioClip[] vrBotReactions4; //S4
    public AudioClip[] vrBotReactions5; //S5
    
    // Deductions
    public AudioClip[] DeductionClips; 


    // This method is for playing VRBot`s voice over
    public void PlaySubtitleVoiceOver(AudioClip audio)
    {
        subtitleSource.clip = audio; 
        subtitleSource.Play();
        // Debug.Log("Voice is played"); 
    }
    public void StopSubtitleVoiceOver(AudioClip audio)
    {
        subtitleSource.clip = audio;
        subtitleSource.Stop();
        // Debug.Log("Voice is stopped");
    }

    // Background Music
    public void PlayBGMusic(AudioClip audio,bool state)
    {
        musicSource.clip = audio;
        if(state)
        {
            musicSource.Play();
        }
        else
        {
            musicSource.Stop();
        }
    }

    // SFX
    public void WhooseFireFX(bool state)
    {
        sfxSource.clip = whooseFire;
        if(state)
        {
            sfxSource.Play();
        }
        else
        {
            sfxSource.Stop();
        }
    }
    public void LighterFX(bool state)
    {
        sfxSource.clip = lighterFX;
        if(state)
        {
            sfxSource.Play();
        }
        else
        {
            sfxSource.Stop();
        }
        // Debug.Log("SFX is played");
    }
    
    public void DoorFX(bool state)
    {
        if(state)
        {
            sfxSource.clip = openDoorFX;
            sfxSource.Play();
        }
        else
        {
            sfxSource.clip = closeDoorFX;
            sfxSource.Play();
        }
        // Debug.Log("SFX is played");
    }
    public void CheckpointFX()
    {
        sfxSource.clip = checkpointFX;
        sfxSource.Play();
        // Debug.Log("SFX is played");
    }
    public void CollectedPointFX()
    {
        sfxSource.clip = collectedPointsFX;
        sfxSource.Play();
        // Debug.Log("SFX is played");
    }
    public void VRBotNice()
    {
        subtitleSource.clip = vrBotNice;
        subtitleSource.Play();
        // Debug.Log("voice over is played");
    }
    public void ForgetToCloseValve()
    {
        subtitleSource.clip = forgetToCloseValve;
        subtitleSource.Play();
        // Debug.Log("voice over is played");
    }

    public void PlayPerformance(AudioClip audio)
    {
        subtitleSource.clip = audio;
        subtitleSource.Play();
        // Debug.Log("voice over is played");
    }

    public void PlayVRBotS2Reactions(AudioClip audio)
    {
        subtitleSource.clip = audio;
        subtitleSource.Play();
        // Debug.Log("voice over is played");
    }

    public void PlayVRBotChemReactions(AudioClip audio)
    {
        subtitleSource.clip = audio;
        subtitleSource.Play();
        // Debug.Log("voice over is played");
    }


    public void Lighter2ON()
    {
        sfxSource.clip = lighter2ONFX;
        sfxSource.Play();
    }

    public void Lighter2OFF()
    {
        sfxSource.clip = lighter2OFFFX;
        sfxSource.Play();
    }

    public void GameOverFx()
    {
        gameOverSource.clip = GameOverClip;
        gameOverSource.Play();
    }
    public void PlayDeduction(AudioClip audio)
    {
        deductionSource.clip = audio;
        deductionSource.Play();
    }

    public void GameOverNegativeSound()
    {
        sfxSource.clip = gameoverNegativeSound;
        sfxSource.Play();
    }

    public void TimerFX(bool Play)
    {
        if (Play)
        {
            timerSource.clip = timerfx;
            timerSource.Play();
        }
        else
        {
            timerSource.clip = timerfx;
            timerSource.Stop();
        }
    }
    public void WearCoatFX()
    {
        sfxSource.clip = wearCoatfx;
        sfxSource.Play();
    }
    public void WearGlovesFX()
    {
        sfxSource.clip = wearGlovesfx;
        sfxSource.Play();
    }
    public void WearGogglesFX()
    {
        sfxSource.clip = wearGogglesfx;
        sfxSource.Play();
    }
}
