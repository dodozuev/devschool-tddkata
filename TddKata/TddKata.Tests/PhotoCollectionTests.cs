using System;
using FluentAssertions;
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

    [Test]
    public void WhenCreateAlbum_ShouldSetFirstPhotoAsCover()
    {
        var firstPhoto = new Uri("http://www.photo.com");

        var album = new PhotoAlbum(new[] {firstPhoto});

        album.Cover.Should().Be(firstPhoto);
    }

    [Test]
    public void WhenSetCover_ShouldSetCoverPhoto()
    {
        var coverPhoto = new Uri("http://coverphoto.com");
        var album = new PhotoAlbum(new[] {new Uri("http://www.photo.com")});

        album.Cover = coverPhoto;

        album.Cover.Should().Be(coverPhoto);
    }

    [Test]
    public void WhenRemovePhoto_ShouldRemoveItFromPhotos()
    {
        var firstPhoto = new Uri("http://www.photo.com");
        var secondPhoto = new Uri("http://secondphoto.com");
        var album = new PhotoAlbum(new[] {firstPhoto, secondPhoto});

        album.RemovePhoto(secondPhoto);

        album.Photos.Should().ContainSingle().Which.Should().Be(firstPhoto);
    }

    [Test]
    public void WhenAddPhoto_ShouldAddItToPhotos()
    {
        var firstPhoto = new Uri("http://www.photo.com");
        var secondPhoto = new Uri("http://secondphoto.com");
        var album = new PhotoAlbum(new[] {firstPhoto});

        album.AddPhoto(secondPhoto);

        album.Photos.Should().BeEquivalentTo(new[] {firstPhoto, secondPhoto});
    }
}