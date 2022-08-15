namespace TddKata.PhotoCollection;

public class PhotoAlbum
{
    public IReadOnlyCollection<Uri> Photos => _photos;

    public Uri Cover
    {
        get => _cover;
        set
        {
            if (!_photos.Contains(value))
            {
                throw new InvalidOperationException("Cover should exist inside the photo album. Add it first");
            }

            _cover = value;
        }
    }

    private Uri _cover;

    private List<Uri> _photos;


    public PhotoAlbum(Uri[] photos)
    {
        if (!photos.Any())
            throw new ArgumentException("Album must have at least 1 uri");
        _photos = photos.ToList();
        Cover = _photos.First();
    }

    public void RemovePhoto(Uri photoToRemove)
    {
        if (!_photos.Contains(photoToRemove))
            throw new InvalidOperationException("No such photo found");

        if (_photos.Count == 1)
            throw new InvalidOperationException();

        _photos.Remove(photoToRemove);

        if (_cover == photoToRemove)
            _cover = _photos.First();
    }

    public void AddPhoto(Uri secondPhoto)
    {
        _photos.Add(secondPhoto);
    }
}