﻿using BookStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new BookStoreDbContext();

            db.Authors.Any();
        }
    }
}
