using AlbumViewer.Data.Model;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace AlbumViewer.Data.Context
{
    public class AlbumViewerDataImporter
    {
        public static bool EnsureAlbumData(AlbumDbContext context, string jsonDataFilePath)
        {
            bool hasData = false;
            try
            {
                hasData = context.Albums.Any();
            }
            catch
            {
                context.Database.EnsureCreated(); // just create the schema - no migrations
                hasData = context.Albums.Any();
            }


            if (!hasData)
            {
                string json = System.IO.File.ReadAllText(jsonDataFilePath);
                return ImportFromJson(context, json) > 0;
            }


            return true;
        }

        /// <summary>
        /// Imports data from json
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static int ImportFromJson(AlbumDbContext context, string json)
        {
            var albums = JsonConvert.DeserializeObject<Album[]>(json);

            foreach (var album in albums)
            {
                // clear out primary/identity keys so insert works
                album.Id = 0;
                album.ArtistId = 0;
                album.Artist.Id = 0;

                var existingArtist = context.Artists.FirstOrDefault(a => a.ArtistName == album.Artist.ArtistName);
                if (existingArtist == null)
                {
                    context.Artists.Add(album.Artist);
                }
                else
                {
                    album.Artist = existingArtist;
                    album.ArtistId = existingArtist.Id;
                }

                if (album.Tracks != null)
                {
                    foreach (var track in album.Tracks)
                    {
                        track.Id = 0;
                        context.Tracks.Add(track);
                    }
                }
                context.Add(album);

                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    Console.WriteLine("Error adding: " + album.ArtistId);
                }
            }

            return 1;
        }
    }
}
