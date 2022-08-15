namespace TddKata.PhotoCollection;

public class PhotoAlbum
{
    private readonly Uri[] _photos;

    public PhotoAlbum(Uri[] photos)
    {
        if (!photos.Any())
            throw new ArgumentException("Album must have at least 1 uri");
        _photos = photos;
    }
}