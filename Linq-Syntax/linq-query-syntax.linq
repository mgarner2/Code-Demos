<Query Kind="Expression">
  <Connection>
    <ID>43c68604-e9b2-416f-81d4-94e9c2267db1</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

from anArtistRow in Artists
orderby anArtistRow.Name
where anArtistRow.Name.Contains("ch")
&& anArtistRow.Albums.Count()>1
select anArtistRow

from x in Artists
where x.Albums.Count()>1
select x