﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistsSystem.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Duration { get; set; }

        public Guid AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
