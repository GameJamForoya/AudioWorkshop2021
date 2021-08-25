using UnityEngine;

public class SongTrigger : MonoBehaviour
{
    public MusicManager manager;
    public Song song;

    private void OnTriggerEnter2D(Collider2D other)
    {
        manager.PlaySong(song);
    }
}