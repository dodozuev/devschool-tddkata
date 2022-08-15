namespace TddKata.PhotoCollection;

public class PhotoAlbum
{
    public IReadOnlyCollection<Uri> Photos => _photos;
    public Uri Cover { get; set; }

    private List<Uri> _photos;


    public PhotoAlbum(Uri[] photos)
    {
        if (!photos.Any())
            throw new ArgumentException("Album must have at least 1 uri");
        _photos = photos.ToList();
        Cover = photos.First();
    }
}