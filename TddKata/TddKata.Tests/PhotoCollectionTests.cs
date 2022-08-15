using System;
using NUnit.Framework;
using TddKata.PhotoCollection;

namespace TddKata.Tests;

public class PhotoCollectionTests
{
    [Test]
    public void WhenCreateAlbum_ShouldHaveAtLeastOnePhoto()
    {
        Assert.Throws<ArgumentException>(() => new PhotoAlbum(Array.Empty<Uri>()));
    }
}

