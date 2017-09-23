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
	var p = 21;
	
	var results = from x in Albums
					where x.ArtistId.Equals(p)
					select new ArtistAlbumByReleaseYear {
						Title = x.Title,
						Released = x.ReleaseYear
					};
	results.Dump();
}

// Define other methods and classes here
public class ArtistAlbumByReleaseYear
{
	public string Title {get;set;}
	public int Released {get;set;}
}