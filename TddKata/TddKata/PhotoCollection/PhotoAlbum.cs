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

    public void RemovePhoto(Uri secondPhoto)
    {
        if (_photos.Count == 1)
            throw new InvalidOperationException();

        _photos.Remove(secondPhoto);
    }

    public void AddPhoto(Uri secondPhoto)
    {
        _photos.Add(secondPhoto);
    }
}