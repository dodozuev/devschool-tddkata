namespace TddKata.PhotoCollection;

public class PhotoAlbum : EntityCollectionWithDefault<Uri>
{
    public PhotoAlbum(Uri[] photos) : base(photos)
    {
    }
}