<Query Kind="Expression">
  <Connection>
    <ID>43c68604-e9b2-416f-81d4-94e9c2267db1</ID>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Aggregates
from anAlbum in Albums
where anAlbum.AlbumId == 1
select new
{
	Title = anAlbum.Title,
	ArtistId = anAlbum.ArtistId,
	TrackCount = anAlbum.Tracks.Count(),
	AlbumLength = (from aTrack in anAlbum.Tracks select aTrack.Milliseconds).Sum(),
	MaxTrack = anAlbum.Tracks.Select(aTrack => aTrack.Milliseconds).Max(),
	MinTrack = (from aTrack in anAlbum.Tracks select aTrack.Milliseconds).Min(),
	AvgTrack = (from aTrack in anAlbum.Tracks select aTrack.Milliseconds).Average()
}