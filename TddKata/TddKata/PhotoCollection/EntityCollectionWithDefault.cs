namespace TddKata.PhotoCollection;

public class EntityCollectionWithDefault<T>
{
    public IReadOnlyCollection<T> Photos => _photos;

    public T Cover
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

    private T _cover;

    private List<T> _photos;


    public EntityCollectionWithDefault(T[] photos)
    {
        if (!photos.Any())
            throw new ArgumentException("Album must have at least 1 uri");
        _photos = photos.ToList();
        Cover = _photos.First();
    }

    public void RemovePhoto(T photoToRemove)
    {
        if (!_photos.Contains(photoToRemove))
            throw new InvalidOperationException("No such photo found");

        if (_photos.Count == 1)
            throw new InvalidOperationException();

        _photos.Remove(photoToRemove);

        if (_cover.Equals(photoToRemove))
            _cover = _photos.First();
    }

    public void AddPhoto(T secondPhoto)
    {
        _photos.Add(secondPhoto);
    }
}