<Query Kind="Program">
  <Connection>
    <ID>43c68604-e9b2-416f-81d4-94e9c2267db1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	var results = from anArtist in Artists
					where anArtist.Albums.Count()> 3
					orderby anArtist.Albums.Count() descending, anArtist.Name ascending
					select new ArtistAlbumCollection
					{
						ArtistName = anArtist.Name,
						AlbumCount = anArtist.Albums.Count(),
						AlbumCollection = (from anAlbum in anArtist.Albums
										select new ArtistAlbum
										{
											Title = anAlbum.Title,
											Year = anAlbum.ReleaseYear
										}).ToList()
					};
	results.Dump();
	//return results.ToList();
}

// Define other methods and classes here
//POCO
public class ArtistAlbum
{
	public string Title{get;set;}
	public int Year{get;set;}
}
//DTO
//public class ArtistAlbumCollection
//{
//	public string ArtistName{get;set;}
//	public int AlbumCount{get;set;}
//	public IEnumerable<ArtistAlbum> AlbumCollection{get;set;}
//}
public class ArtistAlbumCollection
{
	public string ArtistName{get;set;}
	public int AlbumCount{get;set;}
	public List<ArtistAlbum> AlbumCollection{get;set;}
}