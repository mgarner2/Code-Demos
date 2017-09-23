<Query Kind="Statements">
  <Connection>
    <ID>43c68604-e9b2-416f-81d4-94e9c2267db1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

var results = 
from anArtistRow in Artists
where anArtistRow.Name.Contains("ch")
&& anArtistRow.Albums.Count()>1
orderby anArtistRow.Name
select new {
	name = anArtistRow.Name,
	albums = anArtistRow.Albums.Count()
};
results.Dump();