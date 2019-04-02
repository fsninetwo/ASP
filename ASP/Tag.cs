using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace ASP
{
    class Tag
    {
        public string artistname(string filename)
        {
            var file = File.Create(filename);
            return file.Tag.FirstArtist.ToString();
        }

        public string albumname(string filename)
        {
            var file = File.Create(filename);
            return file.Tag.Album.ToString();
        }

        public string trackname(string filename)
        {
            var file = File.Create(filename);
            return file.Tag.Title.ToString();
        }

        public string year(string filename)
        {
            var file = File.Create(filename);
            return file.Tag.Year.ToString();
        }
    }
}
