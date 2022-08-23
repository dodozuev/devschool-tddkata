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
        var firstPhoto = new Uri("http://www.photo.com");
        var coverPhoto = new Uri("http://coverphoto.com");
        var album = new PhotoAlbum(new[] {firstPhoto, coverPhoto});

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

    [Test]
    public void WhenRemoveLastPhoto_ShouldThrow()
    {
        var firstPhoto = new Uri("http://www.photo.com");
        var album = new PhotoAlbum(new[] {firstPhoto});

        Assert.Throws<InvalidOperationException>(() => album.RemovePhoto(firstPhoto));
    }

    [Test]
    public void WhenRemoveNonExistentPhoto_ShouldThrow()
    {
        var firstPhoto = new Uri("http://www.photo.com");
        var secondPhoto = new Uri("http://www.secondphoto.com");
        var nonExistentPhoto = new Uri("http://www.nonexistentphoto.com");
        var album = new PhotoAlbum(new[] {firstPhoto, secondPhoto});

        Assert.Throws<InvalidOperationException>(() => album.RemovePhoto(nonExistentPhoto));
    }

    [Test]
    public void WhenSetCoverOfNonExistentPhoto_ShouldThrow()
    {
        var firstPhoto = new Uri("http://www.photo.com");
        var nonExistentPhoto = new Uri("http://www.nonexistentphoto.com");
        var album = new PhotoAlbum(new[] {firstPhoto});

        Assert.Throws<InvalidOperationException>(() => album.Cover = nonExistentPhoto);
    }

    [Test]
    public void WhenCoverOfPhotoIsRemoved_ShouldUpdateCover()
    {
        var firstPhoto = new Uri("http://www.photo.com");
        var secondPhoto = new Uri("http://www.secondphoto.com");
        var album = new PhotoAlbum(new[] {firstPhoto, secondPhoto});

        album.RemovePhoto(firstPhoto);

        album.Cover.Should().Be(secondPhoto);
    }
}