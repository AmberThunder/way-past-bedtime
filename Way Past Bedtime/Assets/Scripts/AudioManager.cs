using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /* Needed sounds
     * footsteps (player, bear, fort) (thomas)
     * item collection
     * battery depleted (thomas)
     * flashlight on & off (thomas)
     * throw pillow, pillow impact
     * player damage
     * baseball swing
     * baseball hit (stock bonk sfx)
     * win jingle
     * music (thomas)
     * button click
     */
    // A manager to control which sounds will play at which points.
    public static AudioSource[] musicList;

    // Dictionary holding Audio Clips
    private static readonly
    IDictionary<string, AudioClip> SoundEffects
        = new Dictionary<string, AudioClip>();

    void Awake()
    {

        // PlayerSound Effects
        SoundEffects.Add("buttonclick", Resources.Load<AudioClip>("SoundEffects/buttonclick"));

    }

    // Plays a sound effect
    public static void PlaySoundEffect(string sound, AudioSource audioSource)
    {
        audioSource.PlayOneShot(SoundEffects[sound]);
    }

    // Plays music
    public static void PlayMusic(string sound, AudioSource audioSource)
    {
        StopMusic();

        audioSource.PlayOneShot(SoundEffects[sound]);
    }

    // Stops Music to avoid multiple tracks at once
    public static void StopMusic()
    {
        // Music to stop based on number of enumerators.
        int firstMusic = 0;
        int secondMusic = 2;

        // Go through entire music list and stop all tracks.
        for (int i = firstMusic; i < secondMusic; i++)
        {
            musicList[i].Stop();
        }

    }
}
