using UnityEngine;

public class SongTrigger : MonoBehaviour
{
    public MusicManager manager;
    public Song song;

    private void Start()
    {
        var collider = GetComponent<Collider2D>();
        if (collider)
        {
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        manager.PlaySong(song);
    }
}